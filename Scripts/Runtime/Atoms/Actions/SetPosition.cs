using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityAtomsUtils.Actions
{
	[CreateAssetMenu(
		menuName = Constants.ActionsCreateAssetMenuPath + "(GameObject) => Set Position")]
	public class SetPosition : AtomAction<GameObject>
	{
		[SerializeField]
		private Vector3Variable targetPosition;

		public override void Do(GameObject entryValue)
		{
			entryValue.transform.position = targetPosition.Value;
		}
	}
}