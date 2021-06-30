using UnityEngine;

namespace UnityUtils
{
	public interface IUnityDespawnService
	{
		public void Despawn<T>(T component, float delay = 0, bool immediate = false) where T : Component;
		public void Despawn(GameObject gameObject, float delay = 0, bool immediate = false);
	}
}