using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class UpdateMonoHookMonoBehaviour : BaseMonoHookMonoBehaviour
    {
        private void Update()
        {
            Call();
        }
    }
}