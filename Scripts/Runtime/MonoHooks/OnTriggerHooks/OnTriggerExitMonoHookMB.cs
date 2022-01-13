using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnTriggerExitMonoHookMB : BaseOnTriggerMonoHookMB
    {
        private void OnTriggerExit(Collider other)
        {
            Call(other);
        }
    }
}