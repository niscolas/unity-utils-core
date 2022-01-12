using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnCollisionStayMonoHookMonoBehaviour : BaseOnCollisionMonoHookMonoBehaviour
    {
        private void OnCollisionStay(Collision other)
        {
            Call(other);
        }
    }
}