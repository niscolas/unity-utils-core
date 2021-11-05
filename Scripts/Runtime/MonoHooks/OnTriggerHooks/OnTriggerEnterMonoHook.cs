using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class OnTriggerEnterMonoHook : BaseOnTriggerMonoHook
    {
        private void OnTriggerEnter(Collider other)
        {
            Call(other);
        }
    }
}