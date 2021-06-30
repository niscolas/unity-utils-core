using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityUtils
{
	[CreateAssetMenu(menuName = Constants.AtomActionsMenuPath + "(int) => Set VSync Count")]
	public class SetVsyncCount : AtomAction<int>
	{
		[SerializeField]
		private IntReference _fixedValue;
		
		public override void Do(int value)
		{
			QualitySettings.vSyncCount = value;
		}

		public override void Do()
		{
			Do(_fixedValue);
		}
	}
}