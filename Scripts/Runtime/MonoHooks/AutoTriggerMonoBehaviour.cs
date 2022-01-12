using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class AutoTriggerMonoBehaviour : CachedMonoBehaviour
    {
        [SerializeField]
        private MonoBehaviourEventType _autoTriggerCallback;

        protected override void Awake()
        {
            base.Awake();
            MonoHooksManagerMonoBehaviour.AutoTrigger(_gameObject, Do, _autoTriggerCallback);
        }

        public abstract void Do();
    }
}