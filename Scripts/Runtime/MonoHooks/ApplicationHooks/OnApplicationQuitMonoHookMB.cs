using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnApplicationQuitMonoHookMB : BaseMonoHookMB
    {
        private void OnApplicationQuit()
        {
            Call();
        }
    }
}