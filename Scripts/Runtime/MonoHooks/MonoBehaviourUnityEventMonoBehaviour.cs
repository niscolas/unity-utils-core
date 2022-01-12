﻿using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Mono Behaviour Unity Event")]
    public class MonoBehaviourUnityEventMonoBehaviour : CachedMonoBehaviour
    {
        [SerializeField]
        private MonoBehaviourEventType _triggerMoment;

        [SerializeField]
        private UnityEvent _onTrigger;

        protected override void Awake()
        {
            base.Awake();

            MonoHooksManagerMonoBehaviour.AutoTrigger(_gameObject, Trigger, _triggerMoment);
        }

        private void Trigger()
        {
            _onTrigger?.Invoke();
        }
    }
}