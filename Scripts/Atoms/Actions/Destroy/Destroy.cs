using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityAtomsUtils.Actions.Destroy
{
	[CreateAssetMenu(
		menuName = Constants.ActionsCreateAssetMenuPath +
		           "(GameObject) => Destroy")]
	public class Destroy : AtomAction<GameObject>
	{
		[SerializeField]
		private FloatReference delay;

		public override void Do(GameObject entryValue)
		{
			Destroy(entryValue, delay.Value);
		}
	}
}