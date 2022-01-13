using System;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class AwakeMonoHookMB : BaseMonoHookMB
    {
        protected override bool BeforeSubscribe(Action action)
        {
            action?.Invoke();
            return false;
        }
    }
}