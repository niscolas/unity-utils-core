using UnityEngine;

namespace Plugins.UnityUtils.Services
{
	public interface IUnitySpawnService
	{
		GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null);
		T Spawn<T>(T componentPrefab, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component;
		void Despawn(Component component, GameObject prefab = null);
		void Despawn(GameObject gameObjectInstance, GameObject prefab = null);
	}
}