using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class DespawnStrategySO : ScriptableObject
    {
        public abstract void Despawn<T>(T component, float delay = 0, bool immediate = false) where T : Component;

        public abstract void Despawn(GameObject gameObject, float delay = 0, bool immediate = false);
    }
}