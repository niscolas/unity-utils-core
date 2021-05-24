using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityUtils
{
	[Serializable]
	public struct DelayWrapper
	{
		[SerializeField]
		private float _seconds;

		[SerializeField]
		private int _frames;

		public float Seconds
		{
			get => _seconds;
			set => _seconds = value;
		}

		public int Frames
		{
			get => _frames;
			set => _frames = value;
		}

		public IEnumerator Delay()
		{
			if (_seconds > 0)
			{
				yield return new WaitForSeconds(_seconds);
			}

			for (int i = 0; i < _frames; i++)
			{
				yield return null;
			}
		}
	}
}