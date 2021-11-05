using System;

namespace niscolas.UnityUtils.Core
{
    public interface IMonoHook
    {
        void Subscribe(Action action);
        void Unsubscribe(Action action);
    }
}