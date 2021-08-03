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

		public static T GetComponentFromRoot<T>(this Component component)
		{
			return GetComponentFromRoot<T>(component.gameObject);
		}

		public static T GetComponentFromRoot<T>(this GameObject gameObject)
		{
			return gameObject.Root().GetComponentInChildren<T>();
		}
	}
}