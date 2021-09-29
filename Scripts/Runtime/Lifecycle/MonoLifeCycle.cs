using System;
using System.Collections.Generic;
using UnityEngine;
using niscolas.UnityExtensions;
using UnityUtils;

namespace niscolas.UnityUtils.Core
{
    public class MonoLifeCycle : MonoBehaviour, IMonoLifeCycle
    {
        public event Action OnAwake;
        public event Action OnEnabled;
        public event Action OnStart;
        public event Action OnUpdate;
        public event Action OnFixedUpdate;
        public event Action OnLateUpdate;
        public event Action OnDisabled;
        public event Action OnDestroyed;

        private static readonly Dictionary<GameObject, MonoLifeCycle> LifeCycles =
            new Dictionary<GameObject, MonoLifeCycle>();

        private bool _hasAwaken;

        public static void GetOrCreate(
            GameObject lifeCycleGameObject, out MonoLifeCycle lifecycle)
        {
            if (!LifeCycles.TryGetValue(lifeCycleGameObject, out lifecycle))
            {
                lifeCycleGameObject.GetOrAddComponent(out lifecycle);
            }
        }

        public static void TriggerOnMoment(
            GameObject subject,
            Action action,
            LifecycleMoment triggerMoment,
            LifecycleMoment unregisterMoment)
        {
            GetOrCreate(subject, out MonoLifeCycle lifecycle);

            lifecycle.AddAction(action, triggerMoment, unregisterMoment);
        }

        public static void TriggerOnMoment(
            GameObject subject, Action action, LifecycleMoment triggerMoment)
        {
            GetOrCreate(subject, out MonoLifeCycle lifecycle);

            lifecycle.AddAction(action, triggerMoment);
        }

        public void AddAction(
            Action action, LifecycleMoment triggerMoment, LifecycleMoment unregisterMoment)
        {
            AddAction(action, triggerMoment);
            RemoveAction(action, unregisterMoment);
        }

        public void AddAction(Action action, LifecycleMoment triggerMoment)
        {
            switch (triggerMoment)
            {
                case LifecycleMoment.Awake:
                    if (_hasAwaken)
                    {
                        action?.Invoke();
                    }
                    else
                    {
                        OnAwake += action;
                    }

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
            LifeCycles.Add(gameObject, this);
            OnAwake?.Invoke();
            _hasAwaken = true;
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
            LifeCycles.Remove(gameObject);
            OnDestroyed?.Invoke();
        }
    }
}