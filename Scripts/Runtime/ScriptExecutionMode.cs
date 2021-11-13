using System;

namespace niscolas.UnityUtils.Core
{
    [Flags]
    public enum ScriptExecutionMode
    {
        EditMode,
        PlayMode,
        Player
    }
}