using UnityEditor;
using UnityEditor.Compilation;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class RecompileScripts
    {
        [MenuItem(Constants.ToolsMenuItemPrefix + "Recompile Scripts")]
        public static void Do()
        {
            CompilationPipeline.RequestScriptCompilation();
        }
    }
}