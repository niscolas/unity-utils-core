using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnCollisionStayMonoHook : BaseOnCollisionMonoHook
    {
        private void OnCollisionStay(Collision other)
        {
            Call(other);
        }
    }
}