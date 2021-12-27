using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class FixedUpdateMonoHook : BaseMonoHook
    {
        private void FixedUpdate()
        {
            Call();
        }
    }
}