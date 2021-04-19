using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace Plugins.UnityUtils {
	public class VideoPlayerManager : MonoBehaviour {
		[Header("Components")]
		[SerializeField]
		private VideoPlayer videoPlayer;

		[Header("Events")]
		[SerializeField]
		private UnityEvent onVideoEnded;

		public void Awake() {
			videoPlayer.loopPointReached += OnEnd;
		}

		private void OnEnd(VideoPlayer eventHandler) {
			onVideoEnded?.Invoke();
		}
	}
}