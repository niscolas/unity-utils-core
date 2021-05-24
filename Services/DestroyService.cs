using UnityEngine;

namespace UnityUtils
{
	public class DestroyService : IUnityDespawnService
	{
		public void Despawn<T>(T component, bool immediate = false) where T : Component
		{
#if UNITY_EDITOR
			if (!Application.isPlaying || immediate)
			{
				Object.DestroyImmediate(component);
				return;
			}
#endif

			Object.Destroy(component);
		}

		public void Despawn(GameObject gameObject, bool immediate = false)
		{
#if UNITY_EDITOR
			if (!Application.isPlaying || immediate)
			{
				Object.DestroyImmediate(gameObject);
				return;
			}
#endif

			Object.Destroy(gameObject);
		}
	}
}