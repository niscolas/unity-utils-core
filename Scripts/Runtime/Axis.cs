using System;

namespace niscolas.UnityUtils.Core
{
    [Flags]
    public enum Axis
    {
        X = 1 << 0,
        Y = 1 << 1,
        Z = 1 << 2
    }
}