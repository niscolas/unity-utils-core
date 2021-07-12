using niscolas.UnityUtils;
using UnityEngine;
using UnityUtils;

namespace Plugins.UnityUtils.Converters
{
	public class GetGameObject : MonoConverter<Component, GameObject>
	{
		[SerializeField]
		private bool _getRoot;

		public override GameObject Inner_Convert(Component entry)
		{
			GameObject otherGameObject = entry.gameObject;
			if (_getRoot)
			{
				otherGameObject = otherGameObject.Root();
			}

			return otherGameObject;
		}
	}
}