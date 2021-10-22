using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public enum EnvironmentType
    {
        EditMode,
        PlayMode,
        Build,
        DebugBuild
    }

    public static class EnvironmentTypeExtensions
    {
        public static EnvironmentType GetCurrentEnvironment()
        {
            if (Application.isEditor)
            {
                if (Application.isPlaying)
                {
                    return EnvironmentType.PlayMode;
                }
                else
                {
                    return EnvironmentType.EditMode;
                }
            }
            
            if (Debug.isDebugBuild)
            {
                return EnvironmentType.DebugBuild;
            }
            else
            {
                return EnvironmentType.Build;
            }
        }

        public static bool IsCurrentEnvironment(this EnvironmentType gameEnvironment)
        {
            return gameEnvironment == GetCurrentEnvironment();
        }
    }
}