using niscolas.UnityUtils;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityAtomsUtils.Actions
{
	[CreateAssetMenu(
		menuName = AtomsConstants.ActionsCreateAssetMenuPath + "(float) => Set Time Scale")]
	public class SetTimeScale : AtomAction<float>
	{
		[SerializeField]
		private FloatReference _fixedValue;
		
		public override void Do(float timeScale)
		{
			Time.timeScale = timeScale;
		}

		public override void Do()
		{
			Do(_fixedValue);
		}
	}
}