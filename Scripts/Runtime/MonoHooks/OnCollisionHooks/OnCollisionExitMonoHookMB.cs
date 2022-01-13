using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnCollisionExitMonoHookMB : BaseOnCollisionMonoHookMB
    {
        private void OnCollisionExit(Collision other)
        {
            Call(other);
        }
    }
}