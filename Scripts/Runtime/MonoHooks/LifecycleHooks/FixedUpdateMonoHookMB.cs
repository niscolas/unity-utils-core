using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class FixedUpdateMonoHookMB : BaseMonoHookMB
    {
        private void FixedUpdate()
        {
            Call();
        }
    }
}