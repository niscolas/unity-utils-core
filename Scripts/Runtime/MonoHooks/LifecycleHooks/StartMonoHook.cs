using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class StartMonoHook : BaseMonoHook
    {
        private void Start()
        {
            Call();
        }
    }
}