using System;
using UnityEditor;
using Object = UnityEngine.Object;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class SelectionUtility
    {
        public static void ForeachAsset(Action<Object> action)
        {
            foreach (Object selectedAsset in Selection.GetFiltered<Object>(SelectionMode.Assets))
            {
                action.Invoke(selectedAsset);
            }
        }
    }
}