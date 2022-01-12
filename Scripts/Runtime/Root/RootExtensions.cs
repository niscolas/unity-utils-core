using niscolas.UnityUtils.Core.Extensions;
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
            return Core.RootMonoBehaviour.CheckIsRoot(gameObject);
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

            RootMonoBehaviour root = gameObject.GetComponentInParent<RootMonoBehaviour>();

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

        public static void IfUnityNullGetComponentFromRoot<T>(
            this GameObject gameObject, ref T component)
        {
            if (component.IsUnityNull())
            {
                component = gameObject.GetComponentFromRoot<T>();
            }
        }

        public static bool TryGetComponentFromRoot<T>(
            this Component component, out T resultComponent) where T : class
        {
            return component.gameObject.TryGetComponentFromRoot(out resultComponent);
        }

        public static bool TryGetComponentFromRoot<T>(
            this GameObject gameObject, out T component) where T : class
        {
            component = gameObject.GetComponentFromRoot<T>();
            return !component.IsUnityNull();
        }

        public static T GetComponentFromRoot<T>(this GameObject gameObject)
        {
            if (!gameObject.TryFindRoot(out GameObject root))
            {
                TheBugger.LogRealWarning(
                    $"[{gameObject.name}] has no root, aborting GetComponent operation.",
                    gameObject);
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