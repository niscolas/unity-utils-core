using UnityEngine;

namespace UnityUtils
{
	public class RigidbodyProperties : IComponentProperties<Rigidbody>
	{
		public float? Drag { get; set; }
		public float? AngularDrag { get; set; }

		public void ApplyTo(Rigidbody component)
		{
			if (Drag != null)
			{
				component.drag = Drag.Value;
			}

			if (AngularDrag != null)
			{
				component.angularDrag = AngularDrag.Value;
			}
		}
	}
}