using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Video Player Control")]
    public class VideoPlayerControlMB : CachedMB
    {
        [SerializeField]
        private VideoPlayer _videoPlayer;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onVideoEnded;

        protected override void Awake()
        {
            base.Awake();
            _videoPlayer.loopPointReached += OnEnd;
        }

        private void OnDestroy()
        {
            _videoPlayer.loopPointReached -= OnEnd;
        }

        private void OnEnd(VideoPlayer eventHandler)
        {
            _onVideoEnded?.Invoke();
        }
    }
}