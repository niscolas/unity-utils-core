using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [CreateAssetMenu(
        menuName = Constants.CoreCreateAssetMenuPrefix + "Unity Destroy Strategy",
        order = Constants.CreateAssetMenuOrder)]
    public class UnityDestroyStrategySO : ServiceBasedDespawnStrategySO<UnityDestroyService> { }
}