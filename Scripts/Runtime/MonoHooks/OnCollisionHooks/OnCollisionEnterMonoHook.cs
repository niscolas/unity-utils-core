using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class OnCollisionEnterMonoHook : BaseOnCollisionMonoHook
    {
        private void OnCollisionEnter(Collision other)
        {
            Call(other);
        }
    }
}