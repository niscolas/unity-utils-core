using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class LateUpdateMonoHookMonoBehaviour : BaseMonoHookMonoBehaviour
    {
        private void LateUpdate()
        {
            Call();
        }
    }
}