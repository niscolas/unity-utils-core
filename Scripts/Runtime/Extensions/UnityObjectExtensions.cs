using UnityEditor;
using UnityEngine;

namespace niscolas.UnityExtensions
{
    public static class UnityObjectExtensions
    {
        private const char UnityDirSeparator = '/';

#if UNITY_EDITOR
        public static string NameWithExtension(this Object asset)
        {
            string assetPath = asset.Path();
            int startIndex = assetPath.LastIndexOf(UnityDirSeparator) + 1;

            return assetPath.Substring(startIndex);
        }

        public static string Path(this Object asset)
        {
            return AssetDatabase.GetAssetPath(asset);
        }

        public static string FolderPath(this Object asset)
        {
            string folderPath = asset.Path().SubstringUntilLastCharacter(UnityDirSeparator);

            return folderPath;
        }

        public static void Create(this Object asset, string fullPath, bool saveAssets = true)
        {
            string fullFolderPath = fullPath.SubstringUntilLastCharacter(UnityDirSeparator);

            if (!AssetDatabase.IsValidFolder(fullFolderPath))
            {
                string parentFolderPath = fullFolderPath.SubstringUntilLastCharacter(UnityDirSeparator);
                int lastDirSeparatorCharIndex = fullFolderPath.LastIndexOf(UnityDirSeparator);
                string newFolderName = fullFolderPath.Substring(lastDirSeparatorCharIndex + 1);

                AssetDatabase.CreateFolder(parentFolderPath, newFolderName);
            }

            AssetDatabase.CreateAsset(asset, fullPath);

            if (saveAssets)
            {
                AssetDatabase.SaveAssets();
            }
        }

        public static void SelfDelete(this Object obj)
        {
            string assetPath = AssetDatabase.GetAssetPath(obj);

            AssetDatabase.DeleteAsset(assetPath);
            AssetDatabase.SaveAssets();
        }

        public static void Rename(this Object obj, string newName)
        {
            string objPath = AssetDatabase.GetAssetPath(obj.GetInstanceID());

            AssetDatabase.RenameAsset(objPath, newName);
            AssetDatabase.SaveAssets();
        }
#endif

        public static bool IsUnityNull(this object obj)
        {
            if (obj is Object unityObj)
            {
                return !unityObj;
            }

            return obj == null;
        }

        public static bool TryGetGameObject(this Object unityObj, out GameObject gameObject)
        {
            gameObject = null;
            switch (unityObj)
            {
                case GameObject possibleGameObject:
                    gameObject = possibleGameObject;
                    return true;

                case Component component:
                    gameObject = component.gameObject;
                    return true;

                default:
                    return false;
            }
        }
    }
}