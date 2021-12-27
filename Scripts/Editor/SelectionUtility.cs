using UnityEditor;
using UnityEngine;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class SelectionUtility
    {
        public static void ForeachAsset(System.Action<Object> action)
        {
            foreach (Object selectedAsset in Selection.GetFiltered<Object>(SelectionMode.Assets))
            {
                action.Invoke(selectedAsset);
            }
        }
    }
}