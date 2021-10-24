using UnityEditor;
using UnityEditor.Compilation;

namespace niscolas.UnityUtils.Core.Editor
{
    public class RecompileScripts
    {
        [MenuItem(Constants.ToolsMenuItemPrefix + "Recompile Scripts")]
        public static void Do()
        {
            CompilationPipeline.RequestScriptCompilation();
        }
    }
}