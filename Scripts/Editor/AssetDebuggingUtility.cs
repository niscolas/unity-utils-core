using niscolas.UnityUtils.Core.Extensions;
using UnityEditor;
using UnityEngine;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class AssetDebuggingUtility
    {
        [MenuItem(Constants.AssetMenuItemPrefix + "Debug Path")]
        public static void DebugPath()
        {
            string debugText = string.Empty;

            SelectionUtility.ForeachAsset(selectedAsset =>
                debugText += $"{selectedAsset.Path()}\n");

            Debug.Log(debugText);
        }

        [MenuItem(Constants.AssetMenuItemPrefix + "Debug Folder Path")]
        public static void DebugFolderPath()
        {
            string debugText = string.Empty;

            SelectionUtility.ForeachAsset(selectedAsset =>
                debugText += $"{selectedAsset.FolderPath()}\n");

            Debug.Log(debugText);
        }

        [MenuItem(Constants.AssetMenuItemPrefix + "Debug Name with Extension")]
        public static void DebugNameWithExtension()
        {
            string debugText = string.Empty;

            SelectionUtility.ForeachAsset(selectedAsset =>
                debugText += $"{selectedAsset.NameWithExtension()}\n");

            Debug.Log(debugText);
        }
    }
}