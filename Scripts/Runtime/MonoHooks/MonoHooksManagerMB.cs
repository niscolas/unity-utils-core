using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class MonoHooksManagerMB : CachedMonoBehaviour
    {
        private static readonly Dictionary<MonoBehaviourEventType, Type> CallbackAndHookTypeRelation =
            new()
            {
                {MonoBehaviourEventType.Awake, typeof(AwakeMonoHookMB)},
                {MonoBehaviourEventType.OnEnable, typeof(OnEnableMonoHookMB)},
                {MonoBehaviourEventType.Start, typeof(StartMonoHookMB)},
                {MonoBehaviourEventType.Update, typeof(UpdateMonoHookMB)},
                {MonoBehaviourEventType.FixedUpdate, typeof(FixedUpdateMonoHookMB)},
                {MonoBehaviourEventType.LateUpdate, typeof(LateUpdateMonoHookMB)},
                {MonoBehaviourEventType.OnDisable, typeof(OnDisableMonoHookMB)},
                {MonoBehaviourEventType.OnDestroy, typeof(OnDestroyMonoHookMB)},
                {MonoBehaviourEventType.OnApplicationQuit, typeof(OnApplicationQuitMonoHookMB)}
            };

        private static readonly Dictionary<GameObject, MonoHooksManagerMB> Managers = new();

        private readonly Dictionary<MonoBehaviourEventType, IMonoHook> _hooks = new();

        protected override void Awake()
        {
            base.Awake();

            Managers.Add(_gameObject, this);
        }

        private void OnDestroy()
        {
            Managers.Remove(_gameObject);
        }

        public static void GetOrCreate(GameObject target, out MonoHooksManagerMB monoHookManager)
        {
            if (!Managers.TryGetValue(target, out monoHookManager))
            {
                target.GetOrAddComponent(out monoHookManager);
            }
        }

        public static void AutoTrigger(
            GameObject target,
            Action action,
            MonoBehaviourEventType triggerCallbackType,
            MonoBehaviourEventType unregisterMoment)
        {
            GetOrCreate(target, out MonoHooksManagerMB monoHookManager);
            monoHookManager.AddAction(action, triggerCallbackType, unregisterMoment);
        }

        public static void AutoTrigger(
            GameObject target, Action action, MonoBehaviourEventType triggerCallbackType)
        {
            GetOrCreate(target, out MonoHooksManagerMB monoHookManager);
            monoHookManager.AddAction(action, triggerCallbackType);
        }

        public void AddAction(
            Action action,
            MonoBehaviourEventType triggerCallbackType,
            MonoBehaviourEventType unregisterCallbackType)
        {
            AddAction(action, triggerCallbackType);
            RemoveAction(action, unregisterCallbackType);
        }

        public void AddAction(Action action, MonoBehaviourEventType monoCallbackType)
        {
            if (!_gameObject)
            {
                action.Invoke();
                return;
            }

            if (!TryGetMonoHook(
                    monoCallbackType,
                    true,
                    out IMonoHook monoHook))
            {
                return;
            }

            monoHook.Subscribe(action);
        }

        public void RemoveAction(Action action, MonoBehaviourEventType monoCallbackType)
        {
            if (!TryGetMonoHook(
                    monoCallbackType,
                    false,
                    out IMonoHook monoHook))
            {
                return;
            }

            monoHook.Unsubscribe(action);
        }

        private bool TryGetMonoHook(
            MonoBehaviourEventType monoCallbackType,
            bool shouldAddIfMissing,
            out IMonoHook monoHook)
        {
            monoHook = default;

            if (monoCallbackType == MonoBehaviourEventType.None)
            {
                return false;
            }

            if (_hooks.TryGetValue(monoCallbackType, out monoHook))
            {
                return true;
            }

            if (!CallbackAndHookTypeRelation.TryGetValue(monoCallbackType, out Type monoHookType))
            {
                return false;
            }

            if (!shouldAddIfMissing)
            {
                return false;
            }

            if (_gameObject.TryGetComponent(monoHookType, out Component component))
            {
                monoHook = component as IMonoHook;
            }
            else
            {
                monoHook = _gameObject.AddComponent(monoHookType) as IMonoHook;
            }

            _hooks.Add(monoCallbackType, monoHook);

            return true;
        }
    }
}