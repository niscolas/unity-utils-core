using niscolas.UniTaskUtils;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils
{
	public class DelayedUnityEvent : MonoBehaviour
	{
		[SerializeField]
		private FloatReference _delaySec;

		[SerializeField]
		private UnityEvent _event;

		public async void Do()
		{
			await Awaiters.Seconds(_delaySec, gameObject);
			_event?.Invoke();
		}
	}
}