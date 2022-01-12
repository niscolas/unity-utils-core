namespace niscolas.UnityUtils.Core
{
    public static class Constants
    {
        public const string AssetMenuItemPrefix = "Assets/" + NiscolasTag + "/";
        public const string AddComponentMenuPrefix = CoreCreateAssetMenuPrefix;
        public const string CoreCreateAssetMenuPrefix = NiscolasCreateAssetMenuPrefix + UnityUtilsCoreTag + "/";
        public const int CreateAssetMenuOrder = -100;
        public const string UnityUtilsCoreTag = "[Core]";
        public const string NiscolasCreateAssetMenuPrefix = NiscolasTag + "/";
        public const string NiscolasTag = "[niscolas]";
        public const string ToolsMenuItemPrefix = "Tools/" + NiscolasTag + "/";
        public const string UnityUtilsCreateAssetMenuPrefix = NiscolasCreateAssetMenuPrefix + UnityUtilsTag + "/";
        public const string UnityUtilsTag = "[Unity Utils]";
    }
}