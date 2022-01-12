using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnDestroyMonoHookMonoBehaviour : BaseMonoHookMonoBehaviour
    {
        private void OnDestroy()
        {
            Call();
        }
    }
}