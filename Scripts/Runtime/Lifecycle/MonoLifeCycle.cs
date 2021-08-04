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

        private static readonly Dictionary<GameObject, MonoLifeCycle> _lifeCycles =
            new Dictionary<GameObject, MonoLifeCycle>();

        public static bool New(GameObject lifeCycleGameObject, out MonoLifeCycle lifecycle)
        {
            if (!_lifeCycles.TryGetValue(lifeCycleGameObject, out lifecycle))
            {
                lifecycle = lifeCycleGameObject.GetOrAddComponent<MonoLifeCycle>();
            }

            return true;
        }

        public static void TriggerOnMoment
        (
            GameObject subject, Action action, LifecycleMoment triggerMoment, LifecycleMoment unregisterMoment
        )
        {
            if (!New(subject, out MonoLifeCycle lifecycle))
            {
                return;
            }

            lifecycle.AddAction(action, triggerMoment, unregisterMoment);
        }

        public static void TriggerOnMoment
        (
            GameObject subject, Action action, LifecycleMoment triggerMoment
        )
        {
            if (!New(subject, out MonoLifeCycle lifecycle))
            {
                return;
            }

            lifecycle.AddAction(action, triggerMoment);
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
            _lifeCycles.Add(gameObject, this);
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
            _lifeCycles.Remove(gameObject);
            OnDestroyed?.Invoke();
        }
    }
}