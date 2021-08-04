using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace niscolas.UnityUtils.Core.Editor
{
    [InitializeOnLoad]
    public class SaveOnPlay
    {
        public static bool IsEnabled { get; set; } = false;

        static SaveOnPlay()
        {
            EditorApplication.playModeStateChanged -= AutoSaveWhenPlaymodeStarts;
            EditorApplication.playModeStateChanged += AutoSaveWhenPlaymodeStarts;
        }

        private static void AutoSaveWhenPlaymodeStarts(PlayModeStateChange playModeStateChange)
        {
            if (!IsEnabled || !EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isPlaying)
            {
                return;
            }

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.isDirty)
                {
                    EditorSceneManager.SaveScene(scene);
                }
            }

            AssetDatabase.SaveAssets();
        }
    }
}