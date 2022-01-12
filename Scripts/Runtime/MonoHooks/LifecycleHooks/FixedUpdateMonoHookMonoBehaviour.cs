using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class FixedUpdateMonoHookMonoBehaviour : BaseMonoHookMonoBehaviour
    {
        private void FixedUpdate()
        {
            Call();
        }
    }
}