using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class ColliderHandledProperties : HandledProperties
    {
        public bool CopyPhysicMaterial { get; set; }
    }

    public class ColliderProperties : IComponentProperties<Collider, ColliderHandledProperties>
    {
        public PhysicMaterial PhysicMaterial { get; set; }

        public void ApplyAll(Collider component)
        {
            ColliderHandledProperties handledProperties = new()
            {
                CopyPhysicMaterial = true
            };
            Apply(component, handledProperties);
        }

        public void Apply(Collider component, ColliderHandledProperties handledProperties)
        {
            if (handledProperties.CopyPhysicMaterial)
            {
                component.sharedMaterial = PhysicMaterial;
            }
        }
    }
}