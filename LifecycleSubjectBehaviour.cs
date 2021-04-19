using System;
using UnityEngine;

namespace Plugins.UnityUtils
{
	public class LifecycleSubjectBehaviour : MonoBehaviour, ILifecycleSubject
	{
		public event Action OnAwake;
		public event Action OnEnabled;
		public event Action OnStarted;
		public event Action OnDisabled;
		public event Action OnDestroyed;

		private void Awake()
		{
			OnAwake?.Invoke();
		}

		private void OnEnable()
		{
			OnEnabled?.Invoke();
		}

		private void Start()
		{
			OnStarted?.Invoke();
		}

		private void OnDisable()
		{
			OnDisabled?.Invoke();
		}

		private void OnDestroy()
		{
			OnDestroyed?.Invoke();
		}
	}
}