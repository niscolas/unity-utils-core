﻿using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Core
{
	public abstract class BaseConverter<TE, TT> : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent<TT> _converted;

		public void Convert(TE entry)
		{
			if (entry == null) return;

			TT convertedValue = Inner_Convert(entry);

			if (convertedValue == null) return;

			_converted?.Invoke(convertedValue);
		}

		public abstract TT Inner_Convert(TE entry);
	}
}