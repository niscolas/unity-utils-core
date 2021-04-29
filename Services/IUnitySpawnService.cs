using UnityEngine;

namespace Plugins.UnityUtils.Services
{
	public interface IUnitySpawnService
	{
		GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null);
		GameObject Spawn(GameObject prefab, Transform parent = null, bool worldPositionStays = false);
		T Spawn<T>(T prefab, Transform parent = null, bool worldPositionStays = false) where T : Component;
		T Spawn<T>(T componentPrefab, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component;
		void Despawn(Component component, GameObject prefab = null);
		void Despawn(GameObject gameObjectInstance, GameObject prefab = null);
	}
}