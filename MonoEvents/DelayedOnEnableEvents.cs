using System.Collections;
using UnityEngine;
using UnityExtensions;

namespace UnityAtomsUtils.MonoBehaviourHelpers.MonoEvents
{
	public class DelayedOnEnableEvents : BaseMonoEvents
	{
		[SerializeField]
		private int _framesDelay = 1;

		[SerializeField]
		private float _secondsDelay;

		private void OnEnable()
		{
			StartCoroutine(DelayedOnEnable());
		}

		private IEnumerator DelayedOnEnable()
		{
			if (_framesDelay > 0)
			{
				yield return StartCoroutine(this.WaitFramesCo(_framesDelay));
			}

			if (_secondsDelay > 0)
			{
				yield return new WaitForSeconds(_secondsDelay);
			}

			Raise();
		}
	}
}