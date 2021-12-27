using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnDisableMonoHook : BaseMonoHook
    {
        private void OnDisable()
        {
            Call();
        }
    }
}