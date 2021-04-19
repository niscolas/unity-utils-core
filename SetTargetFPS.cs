using UnityAtoms;
using UnityAtomsUtils;
using UnityEngine;

namespace Plugins.UnityUtils
{
	[CreateAssetMenu(
		menuName = Constants.ActionsCreateAssetMenuPath + "Set Target FPS")]
	public class SetTargetFPS : AtomAction<int>
	{
		[SerializeField]
		private int _maxFps = 60;

		[SerializeField]
		private bool _performOnEnable;

		private void OnEnable()
		{
			if (_performOnEnable)
			{
				Debug.Log("settings fps");
				Do();
			}
		}

		public override void Do(int entry)
		{
			Application.targetFrameRate = entry;
		}

		public override void Do()
		{
			Do(_maxFps);
		}
	}
}