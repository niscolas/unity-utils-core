using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnApplicationQuitMonoHookMonoBehaviour : BaseMonoHookMonoBehaviour
    {
        private void OnApplicationQuit()
        {
            Call();
        }
    }
}