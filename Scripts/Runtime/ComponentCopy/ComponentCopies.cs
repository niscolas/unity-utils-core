using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class ComponentCopies<TCopy, TComponent, TProperties, THandledProperties> : HashSet<TCopy>
        where TCopy : ComponentCopy<TComponent, TProperties, THandledProperties>, new()
        where TComponent : Component
        where TProperties : IComponentProperties<TComponent, THandledProperties>
        where THandledProperties : HandledProperties
    {
        public void CopyAndApply(TComponent component, TProperties newProperties)
        {
            if (Contains(component))
            {
                return;
            }

            TCopy copy = new TCopy()
            {
                Component = component
            };

            copy.SelfApplyProperties(newProperties);

            Add(copy);
        }

        public void CopyAndApply(TComponent component, TProperties newProperties, THandledProperties handledProperties)
        {
            if (Contains(component))
            {
                return;
            }

            TCopy copy = new TCopy()
            {
                Component = component
            };

            copy.SelfApplyProperties(newProperties, handledProperties);

            Add(copy);
        }

        public void ResetProperties(TComponent component)
        {
            if (!Contains(component) ||
                !TryGetWrapper(component, out TCopy wrapper))
            {
                return;
            }

            wrapper?.ResetProperties();
            Remove(wrapper);
        }

        public bool TryGetWrapper(TComponent component, out TCopy wrapper)
        {
            wrapper = this.FirstOrDefault(
                currentTargetData =>
                    currentTargetData.Component == component);

            return !wrapper.IsUnityNull();
        }

        public bool Contains(TComponent component)
        {
            return this.Any(copy => copy.Component == component);
        }
    }
}