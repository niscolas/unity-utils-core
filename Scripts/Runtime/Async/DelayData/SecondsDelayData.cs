using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [Serializable]
    public class SecondsDelayData
    {
        [SerializeField]
        private float _count = 1;

        public UniTask Wait()
        {
            return Await.Seconds(_count);
        }

        public UniTask Wait(GameObject gameObject)
        {
            return Await.Seconds(_count, gameObject);
        }
    }
}