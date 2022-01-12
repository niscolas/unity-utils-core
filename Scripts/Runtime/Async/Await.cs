using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace niscolas.UnityUtils.Core
{
    public static class Await
    {
        private static GameObject _taskHolderGameObject;

        private static GameObject TaskHolderGameObject
        {
            get
            {
                if (!_taskHolderGameObject)
                {
                    _taskHolderGameObject = new GameObject("[UnityUtils.UniTask_TaskHolder]");
                    Object.DontDestroyOnLoad(_taskHolderGameObject);
                }

                return _taskHolderGameObject;
            }
        }

        public static UniTask Frame(PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            return Frames(1, playerLoopTiming);
        }

        public static UniTask Frames(int count, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            return Frames(count, TaskHolderGameObject, playerLoopTiming);
        }

        public static UniTask Frames
        (
            int count,
            GameObject gameObject,
            PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update
        )
        {
            return UniTask.DelayFrame
            (
                count,
                playerLoopTiming,
                gameObject.GetCancellationTokenOnDestroy()
            );
        }

        public static UniTask Seconds(float seconds, DelayType delayType = DelayType.DeltaTime)
        {
            return Seconds(seconds, TaskHolderGameObject, delayType);
        }

        public static UniTask Seconds(float seconds, GameObject gameObject, DelayType delayType = DelayType.DeltaTime)
        {
            return UniTask.Delay
            (
                TimeSpan.FromSeconds(seconds),
                cancellationToken: gameObject.GetCancellationTokenOnDestroy(),
                delayType: delayType
            );
        }
    }
}
