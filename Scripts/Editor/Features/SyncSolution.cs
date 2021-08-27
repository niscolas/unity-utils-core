using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class SyncSolution
    {
        [MenuItem("Assets/Sync Solution " + MenuItemHotkey.AltShift + "s")]
        public static void Sync()
        {
            var editor = Type.GetType("UnityEditor.SyncVS, UnityEditor");
            var SyncSolution = editor.GetMethod("SyncSolution", BindingFlags.Public | BindingFlags.Static);
            SyncSolution.Invoke(null, null);
            Debug.Log("[solution synced]");
        }
    }
}
