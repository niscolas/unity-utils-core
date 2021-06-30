using UnityEngine;

namespace UnityUtils
{
	public class ColliderToGameObjectConverter : MonoConverter<Collider, GameObject>
	{
		public override GameObject Inner_Convert(Collider entry)
		{
			return entry.gameObject;
		}
	}
}