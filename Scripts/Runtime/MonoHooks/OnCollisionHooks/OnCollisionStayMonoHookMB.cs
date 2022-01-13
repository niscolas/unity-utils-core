using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnCollisionStayMonoHookMB : BaseOnCollisionMonoHookMB
    {
        private void OnCollisionStay(Collision other)
        {
            Call(other);
        }
    }
}