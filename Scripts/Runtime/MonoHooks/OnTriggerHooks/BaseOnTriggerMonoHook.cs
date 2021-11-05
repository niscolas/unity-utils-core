using System;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class BaseOnTriggerMonoHook : BaseMonoHook
    {
        public event Action<Collider> OnColliderTrigger;

        protected void Call(Collider other)
        {
            Call();
            OnColliderTrigger?.Invoke(other);
        }
    }
}