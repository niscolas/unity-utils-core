using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnDestroyMonoHook : BaseMonoHook
    {
        private void OnDestroy()
        {
            Call();
        }
    }
}