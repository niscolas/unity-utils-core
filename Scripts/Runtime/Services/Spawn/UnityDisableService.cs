using niscolas.UniTaskUtils;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	public class UnityDisableService : IDespawnService
	{
		public async void DespawnGameObject<T>(T component, float delay = 0, bool immediate = false) where T : Component
		{
			if (component is Behaviour behaviour)
			{
				await Awaiters.Seconds(delay, component.gameObject);
				behaviour.enabled = false;
			}
		}

		public async void DespawnGameObject(GameObject gameObject, float delay = 0, bool immediate = false)
		{
			await Awaiters.Seconds(delay, gameObject);
			gameObject.SetActive(false);
		}
	}
}