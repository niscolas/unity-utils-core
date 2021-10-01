using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public static class TheBugger
    {
        private static readonly Color SuccessColor = Color.green;
        private static readonly Color ErrorColor = Color.red;
        private static readonly Color WarningColor = Color.yellow;

        public static void LogWithColor(
            string text, Color color, LogType logType, Object context = null)
        {
            Log(
                $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</color>",
                logType,
                context);
        }

        public static void LogSuccess(string text, Object context = null)
        {
            LogWithColor(text, SuccessColor, LogType.Log, context);
        }

        public static void LogRealWarning(string text, Object context = null)
        {
            LogWithColor(text, WarningColor, LogType.Warning, context);
        }

        public static void LogRealError(string text, Object context = null)
        {
            LogWithColor(text, ErrorColor, LogType.Error, context);
        }

        public static void Log(string text, Object context = null)
        {
            Log(text, LogType.Log, context);
        }

        public static void Log(string text, LogType type, Object context = null)
        {
            switch (type)
            {
                case LogType.Warning:
                    Debug.LogWarning(text, context);
                    break;

                case LogType.Error:
                    Debug.LogError(text, context);
                    break;

                default:
                    Debug.Log(text, context);
                    break;
            }
        }
    }
}