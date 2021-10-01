using UnityEngine;

namespace UnityUtils
{
	public interface IDespawnService
	{
		void Despawn<T>(T component, float delay = 0, bool immediate = false) where T : Component;
		void Despawn(GameObject instance, float delay = 0, bool immediate = false);
	}
}
