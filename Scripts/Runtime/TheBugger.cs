using System;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public static class TheBugger
    {
        private static readonly Color SuccessColor = Color.green;
        private static readonly Color ErrorColor = Color.red;
        private static readonly Color WarningColor = Color.yellow;

        public static void LogWithColor(string text, Color color, LogType logType)
        {
            Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</color>",
                logType);
        }

        public static void LogSuccess(string text)
        {
            LogWithColor(text, SuccessColor, LogType.Log);
        }

        public static void LogRealWarning(string text)
        {
            LogWithColor(text, WarningColor, LogType.Warning);
        }
        
        public static void LogRealError(string text)
        {
            LogWithColor(text, ErrorColor, LogType.Error);
        }
        
        public static void Log(string text, LogType type)
        {
            switch (type)
            {
                case LogType.Warning:
                    Debug.LogWarning(text);
                    break;

                case LogType.Error:
                    Debug.LogError(text);
                    break;

                default:
                    Debug.Log(text);
                    break;
            }
        }
    }
}