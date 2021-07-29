using UnityEditor;
using UnityEngine;
using niscolas.UnityExtensions;
using UnityExtensions;

namespace UnityUtils
{
	public class UnityInstantiateService : ISpawnService
	{
		public T Spawn<T>(T component, Transform parent = null, bool worldPositionStays = false) where T : Component
		{
			T instance = Spawn(component.gameObject, parent, worldPositionStays).GetComponent<T>();
			return instance;
		}

		public T Spawn<T>(T component, Vector3 position, Quaternion rotation, Transform parent = null)
			where T : Component
		{
			T instance = Spawn(component.gameObject, position, rotation, parent).GetComponent<T>();
			return instance;
		}

		public GameObject Spawn(GameObject gameObject, Transform parent = null, bool worldPositionStays = false)
		{
#if UNITY_EDITOR
			if (!Application.isPlaying)
			{
				if (gameObject.IsPrefab())
				{
					GameObject instance = PrefabUtility.InstantiatePrefab(gameObject) as GameObject;
					instance.transform.SetParent(parent, worldPositionStays);
					return instance;
				}
			}
#endif
			return Object.Instantiate(gameObject, parent, worldPositionStays);
		}

		public GameObject Spawn(GameObject gameObject, Vector3 position, Quaternion rotation, Transform parent = null)
		{
#if UNITY_EDITOR
			if (!Application.isPlaying)
			{
				if (gameObject.IsPartOfPrefab())
				{
					GameObject instance = PrefabUtility.InstantiatePrefab(gameObject, parent) as GameObject;
					instance.transform.position = position;
					instance.transform.rotation = rotation;
					return instance;
				}
			}
#endif
			return Object.Instantiate(gameObject, position, rotation, parent);
		}
	}
}