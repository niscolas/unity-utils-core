using UnityEngine;

namespace UnityUtils
{
	public abstract class HandledProperties { }

	public abstract class ComponentWrapper<TComponent, TProperties, THandledProperties>
		where TComponent : Component
		where TProperties : IComponentProperties<TComponent, THandledProperties>
		where THandledProperties : HandledProperties
	{
		internal TComponent Component { get; set; }

		private TProperties _originalProperties;

		protected THandledProperties HandledProperties;

		public ComponentWrapper() { }

		protected ComponentWrapper(TComponent component)
		{
			Component = component;
		}

		public ComponentWrapper(TComponent component, THandledProperties handledProperties)
		{
			Component = component;
			HandledProperties = handledProperties;
		}

		public void Apply(TComponent targetComponent)
		{
			TProperties properties = ExtractPropertiesFrom(Component);
			ApplyProperties(properties, targetComponent, HandledProperties);
		}
		
		public void ApplyAll(TComponent targetComponent)
		{
			TProperties properties = ExtractPropertiesFrom(Component);
			ApplyAllProperties(properties, targetComponent);
		}

		public void SelfApplyProperties(TProperties properties)
		{
			if (!Component) return;

			_originalProperties = ExtractPropertiesFrom(Component);

			ApplyAllProperties(properties, Component);
		}

		public void ApplyProperties(TProperties properties, TComponent targetComponent, THandledProperties handledProperties)
		{
			properties.Apply(targetComponent, handledProperties);
		}

		public void ApplyAllProperties(TProperties properties, TComponent targetComponent)
		{
			properties.ApplyAll(targetComponent);
		}

		public void ResetProperties()
		{
			if (!Component) return;

			_originalProperties.ApplyAll(Component);
		}

		protected abstract TProperties ExtractPropertiesFrom(TComponent component);
	}
}