using UnityEngine;

namespace UnityUtils
{
	public static class GameObjectUtility
	{
		public static GameObject FindOrCreate(string gameObjectName)
		{
			GameObject instance = GameObject.Find(gameObjectName);
			
			if (!instance)
			{
				instance = new GameObject(gameObjectName);
			}

			return instance;
		}
	}
}