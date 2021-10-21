using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public enum EnvironmentType
    {
        EditMode,
        PlayMode,
        Player
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
            else
            {
                return EnvironmentType.Player;
            }
        }

        public static bool IsCurrentEnvironment(this EnvironmentType gameEnvironment)
        {
            return gameEnvironment == GetCurrentEnvironment();
        }
    }
}