using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnCollisionEnterMonoHookMonoBehaviour : BaseOnCollisionMonoHookMonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Call(other);
        }
    }
}