using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityUtils
{
	[Serializable]
	public struct RawAndRatioValue
	{
		[SerializeField]
		private FloatReference _rawValue;

		[SerializeField]
		private FloatReference _ratio;

		public float RawValue
		{
			get => _rawValue;
			set => _rawValue.Value = value;
		}

		public float Ratio
		{
			get => _ratio;
			set => _ratio.Value = value;
		}
	}
}