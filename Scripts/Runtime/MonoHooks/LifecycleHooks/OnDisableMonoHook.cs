using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class OnDisableMonoHook : BaseMonoHook
    {
        private void OnDisable()
        {
            Call();
        }
    }
}