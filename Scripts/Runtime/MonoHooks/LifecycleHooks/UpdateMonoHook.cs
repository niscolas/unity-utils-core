using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class UpdateMonoHook : BaseMonoHook
    {
        private void Update()
        {
            Call();
        }
    }
}