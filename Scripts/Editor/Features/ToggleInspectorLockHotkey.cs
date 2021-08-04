using UnityEditor;

namespace niscolas.UnityUtils.Core.Editor
{
    public class ToggleInspectorLockHotkey
    {
        [MenuItem("Tools/[niscolas]/Toggle Lock &q")]
        static void Toggle()
        {
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }
    }
}