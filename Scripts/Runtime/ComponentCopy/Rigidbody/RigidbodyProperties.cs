using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class RigidbodyHandledProperties : HandledProperties
    {
        public bool CopyMass { get; set; }
        public bool CopyDrag { get; set; }
        public bool CopyAngularDrag { get; set; }
        public bool CopyUseGravity { get; set; }
        public bool CopyIsKinematic { get; set; }
        public bool CopyInterpolation { get; set; }
        public bool CopyCollisionDetectionMode { get; set; }
    }

    public class RigidbodyProperties : IComponentProperties<Rigidbody, RigidbodyHandledProperties>
    {
        public float Mass { get; set; }
        public float Drag { get; set; }
        public float AngularDrag { get; set; }
        public bool UseGravity { get; set; }
        public bool IsKinematic { get; set; }
        public RigidbodyInterpolation Interpolation { get; set; }
        public CollisionDetectionMode CollisionDetectionMode { get; set; }

        public void ApplyAll(Rigidbody component)
        {
            RigidbodyHandledProperties handledProperties = new RigidbodyHandledProperties()
            {
                CopyMass = true,
                CopyDrag = true,
                CopyAngularDrag = true,
                CopyUseGravity = true,
                CopyIsKinematic = true,
                CopyInterpolation = true,
                CopyCollisionDetectionMode = true
            };

            Apply(component, handledProperties);
        }

        public void Apply(Rigidbody component, RigidbodyHandledProperties handledProperties)
        {
            if (handledProperties.CopyMass)
            {
                component.mass = Mass;
            }

            if (handledProperties.CopyDrag)
            {
                component.drag = Drag;
            }

            if (handledProperties.CopyAngularDrag)
            {
                component.angularDrag = AngularDrag;
            }

            if (handledProperties.CopyUseGravity)
            {
                component.useGravity = UseGravity;
            }

            if (handledProperties.CopyIsKinematic)
            {
                component.isKinematic = IsKinematic;
            }

            if (handledProperties.CopyInterpolation)
            {
                component.interpolation = Interpolation;
            }

            if (handledProperties.CopyCollisionDetectionMode)
            {
                component.collisionDetectionMode = CollisionDetectionMode;
            }
        }
    }
}