using UnityEngine;

namespace UnityUtils
{
	public class ColliderWrapper : ComponentWrapper<Collider, ColliderProperties>
	{
		public ColliderWrapper() { }

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