using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnCollisionExitMonoHookMonoBehaviour : BaseOnCollisionMonoHookMonoBehaviour
    {
        private void OnCollisionExit(Collision other)
        {
            Call(other);
        }
    }
}