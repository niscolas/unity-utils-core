using UnityEngine;

namespace  UnityUtils
{
	public interface IComponentProperties<in TComponent> where TComponent : Component
	{
		void ApplyTo(TComponent component);
	}
}