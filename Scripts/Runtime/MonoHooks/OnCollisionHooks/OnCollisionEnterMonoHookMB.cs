using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnCollisionEnterMonoHookMB : BaseOnCollisionMonoHookMB
    {
        private void OnCollisionEnter(Collision other)
        {
            Call(other);
        }
    }
}