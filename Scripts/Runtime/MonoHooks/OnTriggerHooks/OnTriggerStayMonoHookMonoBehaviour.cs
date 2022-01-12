using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnTriggerStayMonoHookMonoBehaviour : BaseOnTriggerMonoHookMonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            Call(other);
        }
    }
}