using UnityEngine;

namespace UnityUtils
{
	public class RigidbodyWrapper : ComponentWrapper<Rigidbody, RigidbodyProperties, RigidbodyHandledProperties>
	{
		public RigidbodyWrapper() { }

		public RigidbodyWrapper(Rigidbody component) : base(component) { }

		public RigidbodyWrapper(Rigidbody rigidbody, RigidbodyHandledProperties handledProperties) : base(rigidbody,
			handledProperties) { }

		protected override RigidbodyProperties ExtractPropertiesFrom(Rigidbody component)
		{
			RigidbodyProperties properties = new RigidbodyProperties
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