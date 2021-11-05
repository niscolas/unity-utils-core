using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class LateUpdateMonoHook : BaseMonoHook
    {
        private void LateUpdate()
        {
            Call();
        }
    }
}