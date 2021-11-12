using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils.Core
{
    public abstract class AutoTriggerMonoBehaviour : CachedMonoBehaviour
    {
        [SerializeField]
        private MonoCallbackType _autoTriggerCallback;

        protected abstract void Do();
        
        protected override void Awake()
        {
            base.Awake();
            MonoLifecycleHooksManager.AutoTrigger(_gameObject, Do, _autoTriggerCallback);
        }
    }
}