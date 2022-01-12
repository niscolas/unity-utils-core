using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class StartMonoHookMonoBehaviour : BaseMonoHookMonoBehaviour
    {
        private void Start()
        {
            Call();
        }
    }
}