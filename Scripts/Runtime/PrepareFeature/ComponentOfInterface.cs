using UnityEngine;

// original author: https://github.com/Deadcows

namespace niscolas.UnityUtils.Core
{
    public readonly struct ComponentOfInterface<T>
    {
        public readonly Component Component;
        public readonly T Interface;

        public ComponentOfInterface(Component component, T interfaceParam)
        {
            Component = component;
            Interface = interfaceParam;
        }
    }
}