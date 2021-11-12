using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using UnityEditor;
using Object = UnityEngine.Object;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class AssetDatabaseUtility
    {
        public static T FindFirstAssetOfType<T>() where T : Object
        {
            T result = FindAllAssetsOfType<T>().FirstOrDefault();

            return result;
        }

        public static IEnumerable<T> FindAllAssetsOfType<T>() where T : Object
        {
            return FindAllAssetsOfType(typeof(T)).Cast<T>();
        }

        public static IEnumerable<Object> FindAllAssetsOfType(Type assetType)
        {
            string typeName = assetType.Name;

            string[] assetGuids = AssetDatabase.FindAssets($"t:{typeName}");
            IEnumerable<string> assetPaths = assetGuids.Select(AssetDatabase.GUIDToAssetPath);

            IEnumerable<Object> assets = assetPaths.Select(
                assetPath => AssetDatabase.LoadAssetAtPath(assetPath, assetType));

            return assets;
        }
    }
}