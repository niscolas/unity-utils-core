using System;
using System.Threading.Tasks;
using niscolas.UniTaskUtils;
using niscolas.UnityUtils;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityAtomsUtils
{
	[CreateAssetMenu(
		menuName = AtomsConstants.ActionsCreateAssetMenuPath + "(float) => Timed Action")]
	public class TimedAction : AtomAction<float>
	{
		[SerializeField]
		private FloatReference _fixedWaitTime;

		[SerializeField]
		private UnityEvent _action;

		public override async void Do(float waitTime)
		{
			await Awaiters.Seconds(waitTime);
			_action?.Invoke();
		}

		public override void Do()
		{
			Do(_fixedWaitTime.Value);
		}
	}
}