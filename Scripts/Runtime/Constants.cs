namespace niscolas.UnityUtils.Core
{
    public static class Constants
    {
        public const string AssetMenuItemPrefix = "Assets/" + NiscolasTag + "/";
        public const string AddComponentMenuPrefix = CreateAssetMenuPrefix;
        public const int CreateAssetMenuOrder = -100;
        public const string CreateAssetMenuPrefix = UnityUtilsCreateAssetMenuPrefix + ModuleTag + "/";
        public const string ModuleTag = "[Core]";
        public const string NiscolasCreateAssetMenuPrefix = NiscolasTag + "/";
        public const string NiscolasTag = "[niscolas]";
        public const string ToolsMenuItemPrefix = "Tools/" + NiscolasTag + "/";
        public const string UnityUtilsAddComponentMenuPrefix = UnityUtilsCreateAssetMenuPrefix;
        public const string UnityUtilsCreateAssetMenuPrefix = NiscolasCreateAssetMenuPrefix + UnityUtilsTag + "/";
        public const string UnityUtilsTag = "[Unity Utils]";
    }
}