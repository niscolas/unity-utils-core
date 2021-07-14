using UnityEngine;

namespace UnityUtils
{
	public class CollisionToGameObjectConverter : MonoConverter<Collision, GameObject>
	{
		public override GameObject Inner_Convert(Collision entry)
		{
			return entry.gameObject;
		}
	}
}