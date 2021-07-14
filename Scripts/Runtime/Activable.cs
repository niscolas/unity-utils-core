using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils
{
	public class Activable : MonoBehaviour
	{
		[SerializeField]
		private BoolReference _isActivated;

		[SerializeField]
		private BoolReference _canChangeState = new BoolReference(true);

		[SerializeField]
		private BoolReference _raiseOnStart;

		[Header("Events")]
		[SerializeField]
		private UnityEvent<GameObject> _activated;

		[SerializeField]
		private UnityEvent<GameObject> _deactivated;

		public UnityEvent<GameObject> Activated => _activated;

		public UnityEvent<GameObject> Deactivated => _deactivated;

		public bool IsActivated
		{
			get => _isActivated.Value;
			private set => _isActivated.Value = value;
		}

		public bool CanChangeState => _canChangeState.Value;

		private void Start()
		{
			if (_raiseOnStart.Value)
			{
				NotifyState();
			}
		}

		public void Activate()
		{
			Activate(null);
		}

		public void Activate(GameObject activator)
		{
			if (CanChangeState && !IsActivated)
			{
				IsActivated = true;
				NotifyOnActivated(activator);
			}
		}

		public void Deactivate()
		{
			Deactivate(null);
		}

		public void Deactivate(GameObject deactivator)
		{
			if (CanChangeState && IsActivated)
			{
				IsActivated = false;
				NotifyOnDeactivated(deactivator);
			}
		}

		private void NotifyState()
		{
			NotifyState(null);
		}

		private void NotifyState(GameObject activator)
		{
			if (IsActivated)
			{
				NotifyOnActivated(activator);
			}
			else
			{
				NotifyOnDeactivated(activator);
			}
		}

		private void NotifyOnActivated(GameObject activator)
		{
			_activated?.Invoke(activator);
		}

		private void NotifyOnDeactivated(GameObject deactivator)
		{
			_deactivated?.Invoke(deactivator);
		}
	}
}