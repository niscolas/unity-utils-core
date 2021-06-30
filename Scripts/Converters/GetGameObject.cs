using UnityEngine;
using UnityUtils;

namespace Plugins.UnityUtils.Converters
{
	public class GetGameObject : MonoConverter<Component, GameObject>
	{
		public override GameObject Inner_Convert(Component entry)
		{
			return entry.gameObject;
		}
	}
}