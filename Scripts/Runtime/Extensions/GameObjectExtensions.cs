using System;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityExtensions
{
    public static class GameObjectExtensions
    {
        public static bool IsPrefab(this GameObject gameObject)
        {
            return gameObject.scene.rootCount == 0;
        }

        public static T AddComponent<T>(this GameObject gameObject, T toAdd) where T : Component
        {
            return gameObject.AddComponent<T>().GetCopyOf(toAdd);
        }

        public static void GetOrAddComponent<T>(
            this GameObject gameObject, out T component) where T : Component
        {
            if (!gameObject.TryGetComponent(out component))
            {
                component = gameObject.AddComponent<T>();
            }
        }

        public static T GetComponentInSiblings<T>(this GameObject gameObject)
        {
            Transform parent = gameObject.transform.parent;

            return parent == null ? default : parent.GetComponentInChildren<T>();
        }

        public static void IfUnityNullAddComponent<TTest, TAdd>(
            this GameObject gameObject, ref TTest component)
            where TAdd : Component, TTest
        {
            if (component.IsUnityNull())
            {
                component = gameObject.AddComponent<TAdd>();
            }
        }

        public static void IfUnityNullAddComponent<T>(
            this GameObject gameObject, ref T component) where T : Component
        {
            if (!component)
            {
                component = gameObject.AddComponent<T>();
            }
        }

        public static void IfUnityNullOrEmptyGetComponents<T>(
            this GameObject gameObject,
            ref T[] components,
            bool getComponentsIsChildren = false)
        {
            if (!components.IsNullOrEmpty())
            {
                return;
            }

            if (getComponentsIsChildren)
            {
                components = gameObject.GetComponentsInChildren<T>();
            }
            else
            {
                components = gameObject.GetComponents<T>();
            }
        }

        public static void IfUnityNullGetOrAddComponent<T>(
            this GameObject gameObject, ref T component) where T : Component
        {
            if (component.IsUnityNull())
            {
                gameObject.GetOrAddComponent(out component);
            }
        }

        public static void IfUnityNullGetOrAddComponent<TTest, TAdd>(
            this GameObject gameObject, 
            ref TTest test, 
            bool getComponentInChildren = false)
            where TAdd : Component, TTest
        {
            if (!test.IsUnityNull())
            {
                return;
            }

            if (getComponentInChildren)
            {
                test = gameObject.GetComponentInChildren<TTest>();
            }
            else
            {
                gameObject.TryGetComponent(out test);
            }

            if (test.IsUnityNull())
            {
                test = gameObject.AddComponent<TAdd>();
            }
        }

        public static void IfUnityNullGetComponent<T>(
            this GameObject gameObject,
            ref T component,
            bool getComponentInChildren = false)
        {
            if (!component.IsUnityNull())
            {
                return;
            }

            if (getComponentInChildren)
            {
                component = gameObject.GetComponentFromRoot<T>();
            }
            else
            {
                gameObject.TryGetComponent(out component);
            }
        }

        public static List<GameObject> FindChildrenWithTag(this Transform parent, string tag)
        {
            List<GameObject> taggedGameObjects = new List<GameObject>();

            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child.CompareTag(tag))
                {
                    taggedGameObjects.Add(child.gameObject);
                }

                if (child.childCount > 0)
                {
                    taggedGameObjects.AddRange(child.FindChildrenWithTag(tag));
                }
            }

            return taggedGameObjects;
        }

        public static void SetComponentsState(this GameObject gameObject, bool shouldEnable,
            params Type[] componentTypes)
        {
            foreach (Type componentType in componentTypes)
            {
                if (componentType == null)
                {
                    continue;
                }

                Behaviour component = (Behaviour) gameObject.GetComponent(componentType);
                if (component != null)
                {
                    component.enabled = shouldEnable;
                }
            }
        }

        public static IEnumerable<T> GetComponents<T>(this IEnumerable<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.TryGetComponent(out T component))
                {
                    yield return component;
                }
            }
        }

        public static void Replace(
            this Transform replacement,
            Transform target,
            bool copyPosition,
            bool copyRotation,
            bool copyScale,
            bool copyParent)
        {
            Vector3 position = target.position;
            Quaternion rotation = target.rotation;
            Vector3 scale = target.localScale;
            Transform parent = target.parent;

            if (copyPosition)
            {
                replacement.position = position;
            }

            if (copyRotation)
            {
                replacement.rotation = rotation;
            }

            if (copyScale)
            {
                replacement.localScale = scale;
            }

            if (copyParent)
            {
                replacement.parent = parent;
            }
        }
    }
}