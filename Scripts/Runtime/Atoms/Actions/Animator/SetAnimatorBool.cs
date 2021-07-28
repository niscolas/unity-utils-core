using niscolas.UnityUtils;
using UnityEngine;

namespace UnityAtomsUtils.Actions.SetAnimatorParam
{
	[CreateAssetMenu(
		menuName = AtomsConstants.ActionsCreateAssetMenuPath + "(Animator) => Set Bool")]
	public class SetAnimatorBool : BaseSetAnimatorParam<bool>
	{
		public override void Do(Animator animator)
		{
			animator.SetBool(paramName.Value, value);
		}
	}
}