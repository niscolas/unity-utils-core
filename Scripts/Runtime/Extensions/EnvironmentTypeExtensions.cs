using UnityEngine;

namespace niscolas.UnityUtils.Core
{
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

                return EnvironmentType.EditMode;
            }

            if (Debug.isDebugBuild)
            {
                return EnvironmentType.DebugBuild;
            }

            return EnvironmentType.Build;
        }

        public static bool IsCurrentEnvironment(this EnvironmentType gameEnvironment)
        {
            return gameEnvironment == GetCurrentEnvironment();
        }
    }
}