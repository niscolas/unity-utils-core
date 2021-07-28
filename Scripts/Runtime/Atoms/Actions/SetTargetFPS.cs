using niscolas.UnityUtils;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityAtomsUtils
{
	[CreateAssetMenu(menuName = AtomsConstants.ActionsCreateAssetMenuPath + "(int) => Set Target FPS")]
	public class SetTargetFPS : AtomAction<int>
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