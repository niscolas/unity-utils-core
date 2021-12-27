using niscolas.UnityUtils.Core.Extensions;
using UnityEditor;
using UnityEngine;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class AssetNamer
    {
        [MenuItem(Constants.AssetMenuItemPrefix + "Naming/snake_case => camelCase")]
        public static void FromSnakeCaseToCamelCaseAll()
        {
            SelectionUtility.ForeachAsset(FromSnakeCaseToCamelCase);
        }

        public static void FromSnakeCaseToCamelCase(Object asset)
        {
            asset.Rename(asset.name.FromSnakeToCamelCase());
        }

        [MenuItem(Constants.AssetMenuItemPrefix + "Naming/snake_case => PascalCase")]
        public static void FromSnakeCaseToPascalCaseAll()
        {
            SelectionUtility.ForeachAsset(FromSnakeCaseToPascalCase);
        }

        public static void FromSnakeCaseToPascalCase(Object asset)
        {
            asset.Rename(asset.name.FromSnakeToPascalCase());
        }
    }
}