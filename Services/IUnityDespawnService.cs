using UnityEngine;

namespace UnityUtils
{
	public interface IUnityDespawnService
	{
		public void Despawn<T>(T component, bool immediate = false) where T : Component;
		public void Despawn(GameObject gameObject, bool immediate = false);
	}
}