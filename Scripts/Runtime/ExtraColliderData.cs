using niscolas.UnityExtensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class ExtraColliderData : CachedMonoBehaviour
    {
        [SerializeField]
        private Collider _collider;
        
        [ShowInInspector]
        public Vector3 Size { get; private set; }
        
        public void Start()
        {
            _gameObject.IfUnityNullGetComponent(ref _collider);
            
            if (_collider is BoxCollider boxCollider)
            {
                Size = boxCollider.size;
                return;
            }

            if (_collider is SphereCollider sphereCollider)
            {
                Size = sphereCollider.radius * Vector3.one;
                return;
            }

            if (_collider is CapsuleCollider capsuleCollider)
            {
                Size = capsuleCollider.radius * Vector3.one;
                return;
            }

            if (_collider is MeshCollider meshCollider)
            {
                Size = meshCollider.sharedMesh.bounds.size;
                return;
            }
        }
    }
}