using UnityEditor;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class ToggleInspectorLockHotkey
    {
        [MenuItem("Tools/[niscolas]/Toggle Lock " + MenuItemHotkey.Alt + "q")]
        private static void Toggle()
        {
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }
    }
}