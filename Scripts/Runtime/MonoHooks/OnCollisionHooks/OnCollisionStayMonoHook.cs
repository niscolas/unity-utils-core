using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class OnCollisionStayMonoHook : BaseOnCollisionMonoHook
    {
        private void OnCollisionStay(Collision other)
        {
            Call(other);
        }
    }
}