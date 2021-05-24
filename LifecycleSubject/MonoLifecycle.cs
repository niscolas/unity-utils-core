using System;
using UnityEngine;
using UnityExtensions;

namespace UnityUtils
{
	public class MonoLifecycle : MonoBehaviour, ILifecycle
	{
		public event Action OnAwake;
		public event Action OnEnabled;
		public event Action OnStart;
		public event Action OnUpdate;
		public event Action OnFixedUpdate;
		public event Action OnLateUpdate;
		public event Action OnDisabled;
		public event Action OnDestroyed;

		public static void TriggerOnMoment(
			GameObject subject, Action action, LifecycleMoment triggerMoment, LifecycleMoment unregisterMoment)
		{
			if (!New(subject, out MonoLifecycle lifecycle)) return;
			
			lifecycle.AddAction(action, triggerMoment, unregisterMoment);
		}

		public static void TriggerOnMoment(
			GameObject subject, Action action, LifecycleMoment triggerMoment)
		{
			if (!New(subject, out MonoLifecycle lifecycle)) return;

			lifecycle.AddAction(action, triggerMoment);
		}

		public static bool New(GameObject subject, out MonoLifecycle lifecycle)
		{
			lifecycle = default;
			if (!subject)
			{
				return false;
			}

			lifecycle = subject.GetOrAddComponent<MonoLifecycle>();
			return true;
		}

		public void AddAction(Action action, LifecycleMoment triggerMoment, LifecycleMoment unregisterMoment)
		{
			AddAction(action, triggerMoment);
			RemoveAction(action, unregisterMoment);
		}

		public void AddAction(Action action, LifecycleMoment triggerMoment)
		{
			switch (triggerMoment)
			{
				case LifecycleMoment.Awake:
					OnAwake += action;
					break;

				case LifecycleMoment.OnEnable:
					OnEnabled += action;
					break;

				case LifecycleMoment.Start:
					OnStart += action;
					break;

				case LifecycleMoment.Update:
					OnUpdate += action;
					break;

				case LifecycleMoment.FixedUpdate:
					OnFixedUpdate += action;
					break;

				case LifecycleMoment.LateUpdate:
					OnLateUpdate += action;
					break;

				case LifecycleMoment.OnDisable:
					OnDisabled += action;
					break;

				case LifecycleMoment.OnDestroy:
					OnDestroyed += action;
					break;
			}
		}
		
		public void RemoveAction(Action action, LifecycleMoment triggerMoment)
		{
			switch (triggerMoment)
			{
				case LifecycleMoment.Awake:
					OnAwake -= action;
					break;

				case LifecycleMoment.OnEnable:
					OnEnabled -= action;
					break;

				case LifecycleMoment.Start:
					OnStart -= action;
					break;

				case LifecycleMoment.Update:
					OnUpdate -= action;
					break;

				case LifecycleMoment.FixedUpdate:
					OnFixedUpdate -= action;
					break;

				case LifecycleMoment.LateUpdate:
					OnLateUpdate -= action;
					break;

				case LifecycleMoment.OnDisable:
					OnDisabled -= action;
					break;

				case LifecycleMoment.OnDestroy:
					OnDestroyed -= action;
					break;
			}
		}

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
			OnStart?.Invoke();
		}

		private void Update()
		{
			OnUpdate?.Invoke();
		}

		private void FixedUpdate()
		{
			OnFixedUpdate?.Invoke();
		}

		private void LateUpdate()
		{
			OnLateUpdate?.Invoke();
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