using System;
using System.Reflection;
using UnityEngine;

namespace niscolas.UnityExtensions
{
	public static class ComponentExtensions
	{
		public static Vector3 Position(this Component component)
		{
			return component.transform.position;
		}
		
		public static Vector3 LocalPosition(this Component component)
		{
			return component.transform.localPosition;
		}
		
		public static Quaternion Rotation(this Component component)
		{
			return component.transform.rotation;
		}
		
		public static Quaternion LocalRotation(this Component component)
		{
			return component.transform.localRotation;
		}
		
		public static Vector3 Scale(this Component component)
		{
			return component.transform.localScale;
		}
		
		public static Vector3 LossyScale(this Component component)
		{
			return component.transform.lossyScale;
		}
		
		public static T GetCopyOf<T>(this Component component, T other) where T : Component
		{
			Type type = component.GetType();

			if (type != other.GetType()) return null;

			BindingFlags flags = BindingFlags.Public | 
			                     BindingFlags.NonPublic | 
			                     BindingFlags.Instance | 
			                     BindingFlags.Default |
			                     BindingFlags.DeclaredOnly;
			
			PropertyInfo[] propertyInfos = type.GetProperties(flags);
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				if (!propertyInfo.CanWrite)
				{
					continue;
				}

				try
				{
					propertyInfo.SetValue(component, propertyInfo.GetValue(other, null), null);
				}
				catch { }
			}

			FieldInfo[] fieldInfos = type.GetFields(flags);
			foreach (FieldInfo fieldInfo in fieldInfos)
			{
				fieldInfo.SetValue(component, fieldInfo.GetValue(other));
			}

			return component as T;
		}
	}
}