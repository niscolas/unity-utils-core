using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class FixedUpdateMonoHook : BaseMonoHook
    {
        private void FixedUpdate()
        {
            Call();
        }
    }
}