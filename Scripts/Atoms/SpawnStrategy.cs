using UnityEngine;

namespace UnityUtils
{
	public abstract class SpawnStrategy : ScriptableObject, IUnitySpawnService
	{
		public abstract GameObject Spawn(
			GameObject gameObject, Vector3 position, Quaternion rotation, Transform parent = null);

		public abstract GameObject Spawn(
			GameObject gameObject, Transform parent = null, bool worldPositionStays = false);

		public abstract T Spawn<T>(
			T component, Transform parent = null, bool worldPositionStays = false) where T : Component;

		public abstract T Spawn<T>(
			T component, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component;
	}
}