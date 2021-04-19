using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityExtensions;

namespace UnityUtils
{
	public class ComponentWrappers<TWrapper, TComponent, TProperties>
		where TWrapper : ComponentWrapper<TComponent, TProperties>, new()
		where TComponent : Component
		where TProperties : IComponentProperties<TComponent>
	{
		private readonly IList<TWrapper> _wrappers = new List<TWrapper>();

		public void CreateFrom(TComponent component, TProperties newProperties)
		{
			if (Contains(component)) return;

			TWrapper wrapper = new TWrapper
			{
				Component = component
			};

			wrapper.SetNewProperties(newProperties);

			Add(wrapper);
		}

		public void Add(TWrapper wrapper)
		{
			_wrappers.AddIfNotContains(wrapper);
		}

		public void Remove(TWrapper wrapper)
		{
			_wrappers.SafeRemove(wrapper);
		}

		public void ResetProperties(TComponent component)
		{
			if (!Contains(component) ||
			    !TryGetWrapper(component, out TWrapper wrapper)) return;

			wrapper?.ResetProperties();
			Remove(wrapper);
		}

		public bool TryGetWrapper(TComponent component, out TWrapper wrapper)
		{
			wrapper = _wrappers.FirstOrDefault(
				currentTargetData =>
					currentTargetData.Component == component);

			return !wrapper.IsNull();
		}

		public bool Contains(TComponent component)
		{
			for (int i = 0; i < _wrappers.Count; i++)
			{
				if (_wrappers[i].Component == component)
				{
					return true;
				}
			}

			return false;
		}
	}
}