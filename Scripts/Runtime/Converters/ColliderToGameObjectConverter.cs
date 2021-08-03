using UnityEngine;

namespace niscolas.UnityUtils.Core
{
	public class ColliderToGameObjectConverter : BaseConverter<Collider, GameObject>
	{
		public override GameObject Inner_Convert(Collider entry)
		{
			return entry.gameObject;
		}
	}
}