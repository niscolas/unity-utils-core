using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class AutoTriggerMonoBehaviour : CachedMonoBehaviour
    {
        [SerializeField]
        private MonoCallbackType _autoTriggerCallback;

        protected override void Awake()
        {
            base.Awake();
            MonoLifecycleHooksManager.AutoTrigger(_gameObject, Do, _autoTriggerCallback);
        }

        public abstract void Do();
    }
}