using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnTriggerEnterMonoHookMonoBehaviour : BaseOnTriggerMonoHookMonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Call(other);
        }
    }
}