using System;

namespace niscolas.UnityUtils.Core
{
    [Flags]
    public enum ScriptExecutionMode
    {
        None = 0,
        EditMode = 1 << 0,
        PlayMode = 1 << 1,
        Player = 1 << 2,
        All = EditMode | PlayMode | Player
    }
}