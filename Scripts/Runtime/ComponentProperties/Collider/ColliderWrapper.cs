using UnityEngine;

namespace UnityUtils
{
	public class ColliderWrapper : ComponentWrapper<Collider, ColliderProperties, ColliderHandledProperties>
	{
		public ColliderWrapper() { }

		public ColliderWrapper(Collider collider, ColliderHandledProperties handledProperties) :
			base(collider, handledProperties) { }

		protected override ColliderProperties ExtractPropertiesFrom(Collider component)
		{
			ColliderProperties originalProperties = new ColliderProperties
			{
				PhysicMaterial = component.sharedMaterial
			};

			return originalProperties;
		}
	}
}