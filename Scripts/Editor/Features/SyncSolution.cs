using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class SyncSolution
    {
        [MenuItem(Constants.AssetMenuItemPrefix + "Sync Solution" + MenuItemHotkey.AltShift + "s")]
        public static void Sync()
        {
            Type editor = Type.GetType("UnityEditor.SyncVS, UnityEditor");
            MethodInfo SyncSolution = editor.GetMethod("SyncSolution", BindingFlags.Public | BindingFlags.Static);
            SyncSolution.Invoke(null, null);
            Debug.Log("[solution synced]");
        }
    }
}