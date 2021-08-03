using UnityEngine;

namespace niscolas.UnityUtils.Core
{
	public class CollisionToGameObjectConverter : BaseConverter<Collision, GameObject>
	{
		public override GameObject Inner_Convert(Collision entry)
		{
			return entry.gameObject;
		}
	}
}