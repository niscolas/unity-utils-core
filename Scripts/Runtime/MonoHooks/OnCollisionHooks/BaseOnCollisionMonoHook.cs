﻿using System;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class BaseOnCollisionMonoHook : BaseMonoHook
    {
        public event Action<Collision> OnCollision;

        protected void Call(Collision other)
        {
            Call();
            OnCollision?.Invoke(other);
        }
    }
}