using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class HandledProperties { }

    // TODO refactor component copy system
    public abstract class ComponentCopy<TComponent, TProperties, THandledProperties>
        where TComponent : Component
        where TProperties : IComponentProperties<TComponent, THandledProperties>
        where THandledProperties : HandledProperties
    {
        private TProperties _originalProperties;

        protected THandledProperties HandledProperties;

        public ComponentCopy() { }

        protected ComponentCopy(TComponent component)
        {
            Component = component;
        }

        public ComponentCopy(TComponent component, THandledProperties handledProperties)
        {
            Component = component;
            HandledProperties = handledProperties;
        }

        internal TComponent Component { get; set; }

        protected abstract TProperties ExtractPropertiesFrom(TComponent component);

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
            if (!Component)
            {
                return;
            }

            _originalProperties = ExtractPropertiesFrom(Component);

            ApplyAllProperties(properties, Component);
        }

        public void SelfApplyProperties(TProperties properties, THandledProperties handledProperties)
        {
            if (!Component)
            {
                return;
            }

            _originalProperties = ExtractPropertiesFrom(Component);

            ApplyProperties(properties, Component, handledProperties);
        }

        public void ApplyProperties(
            TProperties properties, TComponent targetComponent, THandledProperties handledProperties)
        {
            properties.Apply(targetComponent, handledProperties);
        }

        public void ApplyAllProperties(TProperties properties, TComponent targetComponent)
        {
            properties.ApplyAll(targetComponent);
        }

        public void ResetProperties()
        {
            if (!Component)
            {
                return;
            }

            _originalProperties.ApplyAll(Component);
        }
    }
}