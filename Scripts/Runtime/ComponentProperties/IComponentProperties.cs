using UnityEngine;

namespace UnityUtils
{
	public interface IComponentProperties<in TComponent, in THandleProperties>
		where TComponent : Component
		where THandleProperties : HandledProperties
	{
		void ApplyAll(TComponent component);
		void Apply(TComponent component, THandleProperties handledProperties);
	}
}