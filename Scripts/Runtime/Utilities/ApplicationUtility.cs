using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public static class ApplicationUtility
    {
        public static bool IsEditMode()
        {
            return Application.isEditor && !Application.isPlaying;
        }
        
        public static bool IsEditorPlayMode()
        {
            return Application.isEditor && Application.isPlaying;
        }

        public static bool IsPlayer()
        {
            return !Application.isEditor;
        }
    }
}