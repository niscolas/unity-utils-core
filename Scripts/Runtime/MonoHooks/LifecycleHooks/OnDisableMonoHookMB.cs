using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnDisableMonoHookMB : BaseMonoHookMB
    {
        private void OnDisable()
        {
            Call();
        }
    }
}