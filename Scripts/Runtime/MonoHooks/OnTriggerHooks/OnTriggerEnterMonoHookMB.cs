using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnTriggerEnterMonoHookMB : BaseOnTriggerMonoHookMB
    {
        private void OnTriggerEnter(Collider other)
        {
            Call(other);
        }
    }
}