using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class UpdateMonoHook : BaseMonoHook
    {
        private void Update()
        {
            Call();
        }
    }
}