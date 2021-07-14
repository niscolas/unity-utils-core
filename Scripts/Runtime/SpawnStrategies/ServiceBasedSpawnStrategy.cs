using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	public abstract class ServiceBasedSpawnStrategy<TSpawnService> : SpawnStrategy
		where TSpawnService : ISpawnService, new()
	{
		private static readonly TSpawnService Service = new TSpawnService();

		public override GameObject Spawn(GameObject gameObject, Vector3 position, Quaternion rotation,
			Transform parent = null)
		{
			return Service.Spawn(gameObject, position, rotation, parent);
		}

		public override GameObject Spawn(GameObject gameObject, Transform parent = null, bool worldPositionStays = false)
		{
			return Service.Spawn(gameObject, parent, worldPositionStays);
		}

		public override T Spawn<T>(T component, Transform parent = null, bool worldPositionStays = false)
		{
			return Service.Spawn(component, parent, worldPositionStays);
		}

		public override T Spawn<T>(T component, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return Service.Spawn(component, position, rotation, parent);
		}
	}
}