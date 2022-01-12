using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [Serializable]
    public class FramesDelayData
    {
        [SerializeField]
        private int _count = 1;

        [SerializeField]
        private PlayerLoopTiming _playerLoopTiming = PlayerLoopTiming.Update;

        public UniTask Wait()
        {
            return Await.Frames(_count, _playerLoopTiming);
        }

        public UniTask Wait(GameObject gameObject)
        {
            return Await.Frames(_count, gameObject, _playerLoopTiming);
        }
    }
}