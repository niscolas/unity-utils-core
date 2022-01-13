using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class AutoTriggerMB : CachedMonoBehaviour
    {
        [SerializeField]
        private MonoBehaviourEventType _autoTriggerCallback;

        protected override void Awake()
        {
            base.Awake();
            MonoHooksManagerMB.AutoTrigger(_gameObject, Do, _autoTriggerCallback);
        }

        public abstract void Do();
    }
}