using System;
using UnityEditor;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class TheEditor
    {
        public static event Action EnteredEditMode;
        public static event Action EnteredPlayMode;
        public static event Action ExitingEditMode;
        public static event Action ExitingPlayMode;


        [InitializeOnLoadMethod]
        private static void Init()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChange;
        }

        private static void OnPlayModeStateChange(PlayModeStateChange playModeStateChange)
        {
            switch (playModeStateChange)
            {
                case PlayModeStateChange.EnteredEditMode:
                    EnteredEditMode?.Invoke();
                    break;

                case PlayModeStateChange.EnteredPlayMode:
                    EnteredPlayMode?.Invoke();
                    break;

                case PlayModeStateChange.ExitingEditMode:
                    ExitingEditMode?.Invoke();
                    break;

                case PlayModeStateChange.ExitingPlayMode:
                    ExitingPlayMode?.Invoke();
                    break;
            }
        }
    }
}