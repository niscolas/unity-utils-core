using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnApplicationQuitMonoHook : BaseMonoHook
    {
        private void OnApplicationQuit()
        {
            Call();
        }
    }
}