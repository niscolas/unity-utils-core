using System;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OnEnableMonoHook : BaseMonoHook
    {
        private void OnEnable()
        {
            Call();
        }

        protected override bool BeforeSubscribe(Action action)
        {
            action?.Invoke();
            return true;
        }
    }
}