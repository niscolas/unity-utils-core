using UnityEditor;
using UnityEngine;

namespace niscolas.UnityUtils.Core.Editor
{
	public class SetRectTransformAnchorsToCornersHotkey
	{
		[MenuItem("Context/RectTransform/Set Anchors to Corners #%&a")]
		private static void SetEasyAnchors()
		{
			GameObject[] gameObjects = Selection.gameObjects;

			foreach (GameObject currentGameObject in gameObjects)
			{
				if (!currentGameObject || !currentGameObject.TryGetComponent(out RectTransform rectTransform))
				{
					continue;
				}

				RectTransform p = currentGameObject.transform.parent.GetComponent<RectTransform>();

				Vector2 offsetMin = rectTransform.offsetMin;
				Vector2 offsetMax = rectTransform.offsetMax;
				Vector2 anchorMin = rectTransform.anchorMin;
				Vector2 anchorMax = rectTransform.anchorMax;

				float parentWidth = p.rect.width;
				float parentHeight = p.rect.height;

				anchorMin = new Vector2(anchorMin.x + offsetMin.x / parentWidth,
					anchorMin.y + offsetMin.y / parentHeight);

				anchorMax = new Vector2(anchorMax.x + offsetMax.x / parentWidth,
					anchorMax.y + offsetMax.y / parentHeight);

				rectTransform.anchorMin = anchorMin;
				rectTransform.anchorMax = anchorMax;

				rectTransform.offsetMin = new Vector2(0, 0);
				rectTransform.offsetMax = new Vector2(0, 0);
				rectTransform.pivot = new Vector2(0.5f, 0.5f);
			}
		}
	}
}