using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnDisableMonoHookMonoBehaviour : BaseMonoHookMonoBehaviour
    {
        private void OnDisable()
        {
            Call();
        }
    }
}