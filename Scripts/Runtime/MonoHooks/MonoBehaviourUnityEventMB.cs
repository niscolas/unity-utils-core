using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Core
{
    public class MonoBehaviourUnityEventMB : CachedMB
    {
        [SerializeField]
        private MonoBehaviourEventType _triggerMoment;

        [SerializeField]
        private UnityEvent _onTrigger;

        protected override void Awake()
        {
            base.Awake();

            MonoHooksManagerMB.AutoTrigger(_gameObject, Trigger, _triggerMoment);
        }

        private void Trigger()
        {
            _onTrigger?.Invoke();
        }
    }
}