using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class EditorSceneLoadGarbageCollector
    {
        [InitializeOnLoadMethod]
        private static void Init()
        {
            EditorSceneManager.sceneOpened += OnSceneOpened;
        }

        private static void OnSceneOpened(Scene scene, OpenSceneMode mode)
        {
            GarbageCollect();
        }

        [MenuItem(Constants.ToolsMenuItemPrefix + "Force Garbage Collection")]
        private static void GarbageCollect()
        {
            EditorUtility.UnloadUnusedAssetsImmediate();
            GC.Collect();
        }
    }
}