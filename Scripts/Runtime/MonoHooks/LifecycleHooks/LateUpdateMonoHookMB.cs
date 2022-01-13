using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class LateUpdateMonoHookMB : BaseMonoHookMB
    {
        private void LateUpdate()
        {
            Call();
        }
    }
}