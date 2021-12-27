using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnTriggerExitMonoHook : BaseOnTriggerMonoHook
    {
        private void OnTriggerExit(Collider other)
        {
            Call(other);
        }
    }
}