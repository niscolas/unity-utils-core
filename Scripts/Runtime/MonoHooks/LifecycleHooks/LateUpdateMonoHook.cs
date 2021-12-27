using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class LateUpdateMonoHook : BaseMonoHook
    {
        private void LateUpdate()
        {
            Call();
        }
    }
}