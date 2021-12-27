using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class RigidbodyCopy : ComponentCopy<Rigidbody, RigidbodyProperties, RigidbodyHandledProperties>
    {
        public RigidbodyCopy() { }

        public RigidbodyCopy(Rigidbody component) : base(component) { }

        public RigidbodyCopy(Rigidbody rigidbody, RigidbodyHandledProperties handledProperties) : base(rigidbody,
            handledProperties) { }

        protected override RigidbodyProperties ExtractPropertiesFrom(Rigidbody component)
        {
            RigidbodyProperties properties = new()
            {
                Mass = component.mass,
                Drag = component.drag,
                AngularDrag = component.angularDrag,
                UseGravity = component.useGravity,
                IsKinematic = component.isKinematic,
                CollisionDetectionMode = component.collisionDetectionMode,
                Interpolation = component.interpolation
            };

            return properties;
        }
    }
}