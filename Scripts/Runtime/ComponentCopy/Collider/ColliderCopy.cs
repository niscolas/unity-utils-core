using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class ColliderCopy : ComponentCopy<Collider, ColliderProperties, ColliderHandledProperties>
    {
        public ColliderCopy() { }

        public ColliderCopy(Collider collider, ColliderHandledProperties handledProperties) :
            base(collider, handledProperties) { }

        protected override ColliderProperties ExtractPropertiesFrom(Collider component)
        {
            ColliderProperties originalProperties = new ColliderProperties()
            {
                PhysicMaterial = component.sharedMaterial
            };

            return originalProperties;
        }
    }
}