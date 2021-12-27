using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class UnityTimeService : IUnityTimeService
    {
        public float DeltaTime => Time.deltaTime;
        public float FixedDeltaTime => Time.fixedDeltaTime;
    }
}