using UnityEngine;

namespace UnityUtils
{
	public class RigidbodyWrapper : ComponentWrapper<Rigidbody, RigidbodyProperties>
	{
		public RigidbodyWrapper() { }

		protected override RigidbodyProperties ExtractPropertiesFrom(Rigidbody component)
		{
			RigidbodyProperties originalProperties = new RigidbodyProperties
			{
				Drag = component.drag,
				AngularDrag = component.angularDrag
			};

			return originalProperties;
		}
	}
}