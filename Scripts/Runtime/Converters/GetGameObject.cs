using niscolas.UnityUtils;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
	public class GetGameObject : BaseConverter<Component, GameObject>
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