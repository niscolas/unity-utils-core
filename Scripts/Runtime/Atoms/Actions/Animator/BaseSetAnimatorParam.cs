using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityAtomsUtils.Actions.SetAnimatorParam
{
	public class BaseSetAnimatorParam<T> : AtomAction<Animator>
	{
		[SerializeField]
		protected StringReference paramName;

		[SerializeField]
		protected T value;
	}
}