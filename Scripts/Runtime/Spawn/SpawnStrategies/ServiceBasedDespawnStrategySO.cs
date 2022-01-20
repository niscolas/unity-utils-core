using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class ServiceBasedDespawnStrategySO<TDespawnService> : DespawnStrategySO
        where TDespawnService : IDespawnService, new()
    {
        private static readonly TDespawnService Service = new TDespawnService();

        public override void Despawn<T>(T component, float delay = 0, bool immediate = false)
        {
            Service.Despawn(component, delay, immediate);
        }

        public override void Despawn(GameObject gameObject, float delay = 0, bool immediate = false)
        {
            Service.Despawn(gameObject, delay, immediate);
        }
    }
}