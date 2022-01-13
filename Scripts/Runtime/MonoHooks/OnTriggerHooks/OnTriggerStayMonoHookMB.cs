using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnTriggerStayMonoHookMB : BaseOnTriggerMonoHookMB
    {
        private void OnTriggerStay(Collider other)
        {
            Call(other);
        }
    }
}