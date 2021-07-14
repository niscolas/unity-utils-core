using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	public abstract class ServiceBasedDespawnStrategy<TDespawnService> : DespawnStrategy
		where TDespawnService : IDespawnService, new()
	{
		private static readonly TDespawnService Service = new TDespawnService();

		public override void Despawn<T>(T component, float delay = 0, bool immediate = false)
		{
			Service.DespawnGameObject(component, delay, immediate);
		}

		public override void Despawn(GameObject gameObject, float delay = 0, bool immediate = false)
		{
			Service.DespawnGameObject(gameObject, delay, immediate);
		}
	}
}