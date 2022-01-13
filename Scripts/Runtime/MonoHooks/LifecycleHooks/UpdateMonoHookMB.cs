using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class UpdateMonoHookMB : BaseMonoHookMB
    {
        private void Update()
        {
            Call();
        }
    }
}