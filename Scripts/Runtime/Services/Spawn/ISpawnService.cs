using UnityEngine;

namespace UnityUtils
{
	public interface ISpawnService
	{
		GameObject Spawn(GameObject gameObject, Vector3 position, Quaternion rotation, Transform parent = null);
		GameObject Spawn(GameObject gameObject, Transform parent = null, bool worldPositionStays = false);
		T Spawn<T>(T component, Transform parent = null, bool worldPositionStays = false) where T : Component;
		T Spawn<T>(T component, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component;
	}
}