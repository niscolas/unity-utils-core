using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnDestroyMonoHookMB : BaseMonoHookMB
    {
        private void OnDestroy()
        {
            Call();
        }
    }
}