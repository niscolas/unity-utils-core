using UnityEngine;

namespace UnityUtils
{
	public interface IDespawnService
	{
		public void DespawnGameObject<T>(T component, float delay = 0, bool immediate = false) where T : Component;
		public void DespawnGameObject(GameObject gameObject, float delay = 0, bool immediate = false);
	}
}