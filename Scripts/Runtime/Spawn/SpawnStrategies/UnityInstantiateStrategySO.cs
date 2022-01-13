using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [CreateAssetMenu(
        menuName = Constants.CreateAssetMenuPrefix + "Unity Instantiate Strategy",
        order = Constants.CreateAssetMenuOrder)]
    public class UnityInstantiateStrategySO : ServiceBasedSpawnStrategySO<UnityInstantiateService> { }
}