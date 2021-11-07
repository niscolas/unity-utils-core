using UnityEngine;
using UnityEngine.Events;
using UnityUtils;

namespace niscolas.UnityUtils.Core
{
    public class UnityEventMonoHook : CachedMonoBehaviour
    {
        [SerializeField]
        private MonoCallbackType _triggerMoment;

        [SerializeField]
        private UnityEvent _onTrigger;

        protected override void Awake()
        {
            base.Awake();
            
            MonoLifecycleHooksManager.AutoTrigger(_gameObject, Trigger, _triggerMoment);
        }

        private void Trigger()
        {
            _onTrigger?.Invoke();
        }
    }
}