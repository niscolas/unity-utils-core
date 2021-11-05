﻿using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [DisallowMultipleComponent]
    public class OnTriggerExitMonoHook : BaseOnTriggerMonoHook
    {
        private void OnTriggerExit(Collider other)
        {
            Call(other);
        }
    }
}