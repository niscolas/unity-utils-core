using UnityEngine;

namespace UnityUtils
{
	public abstract class ComponentWrapper<TComponent, TProperties>
		where TComponent : Component
		where TProperties : IComponentProperties<TComponent>
	{
		internal TComponent Component { get; set; }

		private TProperties _originalProperties;

		public void SetNewProperties(TProperties newProperties)
		{
			if (!Component) return;

			_originalProperties = ExtractPropertiesFrom(Component);

			newProperties.ApplyTo(Component);
		}

		public void ResetProperties()
		{
			if (!Component) return;

			_originalProperties.ApplyTo(Component);
		}

		protected abstract TProperties ExtractPropertiesFrom(TComponent component);
	}
}