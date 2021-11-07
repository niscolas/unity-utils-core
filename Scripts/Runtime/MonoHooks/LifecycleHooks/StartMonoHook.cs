using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class StartMonoHook : BaseMonoHook
    {
        private void Start()
        {
            Call();
        }
    }
}