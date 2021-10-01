// original author: https://github.com/Deadcows

namespace niscolas.UnityUtils.Core.Editor
{
    /// <summary>
    /// Prepare() called on every MonoBehaviour by IPrepareFeature class. If Prepare() returns true, parent scene will be marked dirty 
    /// </summary>
    public interface IPrepare
    {
        bool Prepare();
    }
}