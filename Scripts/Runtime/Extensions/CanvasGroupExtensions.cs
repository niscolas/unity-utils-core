using UnityEngine;

namespace niscolas.UnityExtensions
{
	public static class CanvasGroupExtensions
	{
		public static void SetInteractableAndBlocksRaycasts(this CanvasGroup canvasGroup, bool value)
		{
			canvasGroup.interactable = value;
			canvasGroup.blocksRaycasts = value;
		}
	}
}