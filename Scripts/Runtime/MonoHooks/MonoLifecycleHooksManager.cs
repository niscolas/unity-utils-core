using System;
using System.Collections.Generic;
using niscolas.UnityExtensions;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils.Core
{
    public class MonoLifecycleHooksManager : CachedMonoBehaviour
    {
        private static readonly Dictionary<MonoCallbackType, Type> CallbackAndHookTypeRelation =
            new Dictionary<MonoCallbackType, Type>
            {
                {MonoCallbackType.Awake, typeof(AwakeMonoHook)},
                {MonoCallbackType.OnEnable, typeof(OnEnableMonoHook)},
                {MonoCallbackType.Start, typeof(StartMonoHook)},
                {MonoCallbackType.Update, typeof(UpdateMonoHook)},
                {MonoCallbackType.FixedUpdate, typeof(FixedUpdateMonoHook)},
                {MonoCallbackType.LateUpdate, typeof(LateUpdateMonoHook)},
                {MonoCallbackType.OnDisable, typeof(OnDisableMonoHook)},
                {MonoCallbackType.OnDestroy, typeof(OnDestroyMonoHook)},
                {MonoCallbackType.OnApplicationQuit, typeof(OnApplicationQuitMonoHook)},
            };

        private static readonly Dictionary<GameObject, MonoLifecycleHooksManager> Managers =
            new Dictionary<GameObject, MonoLifecycleHooksManager>();

        private readonly Dictionary<MonoCallbackType, IMonoHook> _hooks = new
            Dictionary<MonoCallbackType, IMonoHook>();

        public static void GetOrCreate(GameObject target, out MonoLifecycleHooksManager monoHookManager)
        {
            if (!Managers.TryGetValue(target, out monoHookManager))
            {
                target.GetOrAddComponent(out monoHookManager);
            }
        }

        public static void AutoTrigger(
            GameObject target,
            Action action,
            MonoCallbackType triggerCallbackType,
            MonoCallbackType unregisterMoment)
        {
            GetOrCreate(target, out MonoLifecycleHooksManager monoHookManager);
            monoHookManager.AddAction(action, triggerCallbackType, unregisterMoment);
        }

        public static void AutoTrigger(
            GameObject target, Action action, MonoCallbackType triggerCallbackType)
        {
            GetOrCreate(target, out MonoLifecycleHooksManager monoHookManager);
            monoHookManager.AddAction(action, triggerCallbackType);
        }

        public void AddAction(
            Action action,
            MonoCallbackType triggerCallbackType,
            MonoCallbackType unregisterCallbackType)
        {
            AddAction(action, triggerCallbackType);
            RemoveAction(action, unregisterCallbackType);
        }

        public void AddAction(Action action, MonoCallbackType monoCallbackType)
        {
            if (!TryGetMonoHook(
                monoCallbackType,
                true,
                out IMonoHook monoHook))
            {
                return;
            }

            monoHook.Subscribe(action);
        }

        public void RemoveAction(Action action, MonoCallbackType monoCallbackType)
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
            MonoCallbackType monoCallbackType,
            bool shouldAddIfMissing,
            out IMonoHook monoHook)
        {
            monoHook = default;

            if (monoCallbackType == MonoCallbackType.None)
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

        protected override void Awake()
        {
            base.Awake();

            Managers.Add(_gameObject, this);
        }

        private void OnDestroy()
        {
            Managers.Remove(_gameObject);
        }
    }
}