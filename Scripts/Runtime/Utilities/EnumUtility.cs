using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace niscolas.UnityUtils
{
	public static class EnumUtility
	{
		public static IEnumerable<T> Values<T>()
		{
			IEnumerable<T> values = (T[]) Enum.GetValues(typeof(T));

			return values;
		}

		public static T RandomValue<T>()
		{
			Array enumValues = Enum.GetValues(typeof(T));
			int randomIndex = Random.Range(0, enumValues.Length);
			T randomValue = (T) enumValues.GetValue(randomIndex);

			return randomValue;
		}
	}
}