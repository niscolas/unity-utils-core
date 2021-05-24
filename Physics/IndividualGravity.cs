﻿using UnityEngine;
using UnityEngine.Assertions;

namespace UnityUtils
{
	public class IndividualGravity : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private bool _compensateDrag;

		private void Start()
		{
			Assert.IsNotNull(_rigidbody);

			_rigidbody.useGravity = false;
		}

		private void FixedUpdate()
		{
			_rigidbody.AddForce(ComputeGravityForce());
		}

		private Vector3 ComputeGravityForce()
		{
			Vector3 result = Physics.gravity * _rigidbody.mass;
			if (_compensateDrag)
			{
				result *= _rigidbody.drag;
			}

			return result;
		}
	}
}