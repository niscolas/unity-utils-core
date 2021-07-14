using UnityAtoms;
using UnityEngine;

namespace UnityAtomsUtils.Actions.SetAnimatorParam
{
	[CreateAssetMenu(
		menuName = Constants.ActionsCreateAssetMenuPath + "(Animator) => Set Trigger")]
	public class SetAnimatorTrigger : BaseSetAnimatorParam<Void>
	{
		public override void Do(Animator animator)
		{
			animator.SetTrigger(paramName.Value);
		}
	}
}