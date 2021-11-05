using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class OnDestroyMonoHook : BaseMonoHook
    {
        private void OnDestroy()
        {
            Call();
        }
    }
}