using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class OnApplicationQuitMonoHook : BaseMonoHook
    {
        private void OnApplicationQuit()
        {
            Call();
        }
    }
}