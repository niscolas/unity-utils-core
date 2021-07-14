using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityExtensions;

namespace UnityUtils
{
	public class BaseMonoEvents : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _events;

		[SerializeField]
		private int _frameDelay;

		protected void Raise()
		{
			StartCoroutine(DelayedRaise());
		}

		private IEnumerator DelayedRaise()
		{
			if (_frameDelay > 0)
			{
				yield return StartCoroutine(this.WaitFramesCo(_frameDelay));
			}
			_events?.Invoke();
		}
	}
}