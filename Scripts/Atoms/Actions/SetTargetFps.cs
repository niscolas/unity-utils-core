using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityAtomsUtils
{
	[CreateAssetMenu(menuName = Constants.ActionsCreateAssetMenuPath + "(int) => Set Target FPS")]
	public class SetTargetFps : AtomAction<int>
	{
		[SerializeField]
		private IntReference _fixedTargetFps;

		public override void Do()
		{
			Do(_fixedTargetFps);
		}

		public override void Do(int entry)
		{
			if (Application.targetFrameRate == entry) return;
			Application.targetFrameRate = entry;
		}
	}
}