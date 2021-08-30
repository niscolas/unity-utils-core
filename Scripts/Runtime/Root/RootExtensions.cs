using niscolas.UnityExtensions;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public static class RootExtensions
    {
        public static bool IsRoot(this Component component)
        {
            return component.gameObject.IsRoot();
        }

        public static bool IsRoot(this GameObject gameObject)
        {
            return Core.Root.CheckIsRoot(gameObject);
        }

        public static GameObject Root(this Component component)
        {
            return component.gameObject.Root();
        }

        public static GameObject Root(this GameObject gameObject)
        {
            if (gameObject.IsRoot())
            {
                return gameObject;
            }

            Root root = gameObject.GetComponentInParent<Root>();

            if (root)
            {
                return root.gameObject;
            }

            return null;
        }

        public static bool TryFindRoot(this GameObject gameObject, out GameObject root)
        {
            root = gameObject.Root();
            return root;
        }

        public static T GetComponentFromRoot<T>(this Component component)
        {
            return GetComponentFromRoot<T>(component.gameObject);
        }

        public static T GetComponentFromRoot<T>(this GameObject gameObject)
        {
            GameObject root = gameObject.Root();
            if (!root)
            {
                Debug.LogWarning($"[{gameObject.name}] has no root, aborting GetComponent operation.");
                return default;
            }

            return root.GetComponentInChildren<T>();
        }

        public static T IfNullGetComponentFromRoot<T>(
                this GameObject gameObject, T component) where T : class
        {
            if (!component.IsUnityNull())
            {
                return component;
            }

            return gameObject.GetComponentFromRoot<T>();
        }
    }
}
