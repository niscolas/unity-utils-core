using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Assertions;
using UnityExtensions;

namespace UnityUtils
{
	[RequireComponent(typeof(Rigidbody))]
	public class DirectionalRigidbodyDrag : MonoBehaviour
	{
		[SerializeField]
		private Vector3Reference _drag = new Vector3Reference(Vector3.one);

		[SerializeField]
		private Rigidbody _rigidbody;

		private Vector3 NewVelocity
		{
			get
			{
				Vector3 velocityWithDrag = _rigidbody.velocity.Multiply(_drag.Value);

				return velocityWithDrag;
			}
		}

		private void Start()
		{
			Assert.IsNotNull(_rigidbody);
		}

		private void Update()
		{
			_rigidbody.velocity = NewVelocity;
		}
	}
}