using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnTriggerExitMonoHookMonoBehaviour : BaseOnTriggerMonoHookMonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Call(other);
        }
    }
}