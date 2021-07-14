using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	[CreateAssetMenu(menuName = Constants.CreateAssetMenuPathPrefix + "Unity Instantiate Strategy")]
	public class UnityInstantiateStrategy : ServiceBasedSpawnStrategy<UnityInstantiateService> { }
}