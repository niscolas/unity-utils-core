using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class OnCollisionExitMonoHook : BaseOnCollisionMonoHook
    {
        private void OnCollisionExit(Collision other)
        {
            Call(other);
        }
    }
}