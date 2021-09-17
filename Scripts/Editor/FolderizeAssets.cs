using UnityEditor;
using UnityEngine;
using niscolas.UnityExtensions;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class FolderizeAssets
    {
        [MenuItem(Constants.AssetMenuItemPrefix + "Folderize Assets")]
        public static void FolderizeSelectedAssets()
        {
            SelectionUtility.ForeachAsset(FolderizeSelectedAsset);
            AssetDatabase.SaveAssets();
        }

        public static void FolderizeSelectedAsset(Object selectedAsset)
        {
            string selectedAssetName = selectedAsset.name;
            string currentFolderPath = selectedAsset.FolderPath();
            
            
            AssetDatabase.CreateFolder(currentFolderPath, selectedAssetName);
            // AssetDatabase.SaveAssets();
            string newFolderPath = $"{currentFolderPath}/{selectedAssetName}";
            
            string oldPath = selectedAsset.Path();
            string newPath = $"{newFolderPath}/{selectedAsset.NameWithExtension()}";
            
            Debug.Log("oldPath: + " + oldPath);
            Debug.Log("newPath: + " + newPath);
            
            AssetDatabase.MoveAsset(oldPath, newPath);
        }
    }
}