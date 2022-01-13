using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class StartMonoHookMB : BaseMonoHookMB
    {
        private void Start()
        {
            Call();
        }
    }
}