﻿using System;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu("")]
    public abstract class BaseMonoHook : CachedMonoBehaviour, IMonoHook
    {
        public event Action OnCallback;

        public void Subscribe(Action action)
        {
            if (!BeforeSubscribe(action))
            {
                return;
            }

            OnCallback += action;
            AfterSubscribe(action);
        }

        public void Unsubscribe(Action action)
        {
            if (!BeforeUnsubscribe(action))
            {
                return;
            }

            OnCallback -= action;
            AfterUnsubscribe(action);
        }

        protected void Call()
        {
            OnCallback?.Invoke();
            AfterCall();
        }

        protected virtual void AfterCall() { }

        protected virtual bool BeforeSubscribe(Action action)
        {
            return true;
        }

        protected virtual void AfterSubscribe(Action action) { }

        protected virtual bool BeforeUnsubscribe(Action action)
        {
            return true;
        }

        protected virtual void AfterUnsubscribe(Action action) { }
    }
}