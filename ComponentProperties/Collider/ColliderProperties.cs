using UnityEngine;

namespace UnityUtils
{
	public class ColliderProperties : IComponentProperties<Collider>
	{
		public PhysicMaterial PhysicMaterial { get; set; }

		public void ApplyTo(Collider component)
		{
			component.sharedMaterial = PhysicMaterial;
		}
	}
}