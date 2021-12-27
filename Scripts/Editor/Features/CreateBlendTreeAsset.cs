using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class CreateBlendTreeAsset
    {
        [MenuItem(Constants.ToolsMenuItemPrefix + "Create BlendTree")]
        private static void CreateBlendTree()
        {
            if (!(Selection.activeObject is BlendTree blendTree))
            {
                return;
            }

            blendTree = Object.Instantiate(blendTree);
            AssetDatabase.CreateAsset(blendTree, $"Assets/{blendTree.name}.asset");
        }
    }
}