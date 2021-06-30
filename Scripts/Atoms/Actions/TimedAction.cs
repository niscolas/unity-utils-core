using System;
using System.Threading.Tasks;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace UnityAtomsUtils.Actions
{
	[CreateAssetMenu(
		menuName = Constants.ActionsCreateAssetMenuPath + "(float) => Timed Action")]
	public class TimedAction : AtomAction<float>
	{
		[SerializeField]
		private FloatReference _fixedWaitTime;

		[SerializeField]
		private UnityEvent _action;

		public override async void Do(float waitTime)
		{
			await Task.Delay(TimeSpan.FromSeconds(waitTime));
			_action?.Invoke();
		}

		public override void Do()
		{
			Do(_fixedWaitTime.Value);
		}
	}
}