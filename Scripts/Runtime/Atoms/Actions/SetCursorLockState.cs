using UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Atoms
{
	[CreateAssetMenu(menuName = AtomsConstants.ActionsCreateAssetMenuPath + "Set Cursor Lock State")]
	public class SetCursorLockState : AtomAction<CursorLockMode>
	{
		[SerializeField]
		private CursorLockMode _lockMode;

		public override void Do(CursorLockMode lockMode)
		{
			Cursor.lockState = lockMode;
		}

		public override void Do()
		{
			Cursor.lockState = _lockMode;
		}
	}
}