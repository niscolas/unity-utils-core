using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnTriggerStayMonoHook : BaseOnTriggerMonoHook
    {
        private void OnTriggerStay(Collider other)
        {
            Call(other);
        }
    }
}