using UnityEngine;

namespace UnityUtils
{
	public class SavePosition : SaveTransform
	{
		protected override Vector3 GetSaveValue()
		{
			return transform.position;
		}
	}
}