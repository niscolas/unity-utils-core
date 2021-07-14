using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	[CreateAssetMenu(menuName = Constants.CreateAssetMenuPathPrefix + "Unity Destroy Strategy")]
	public class UnityDestroyStrategy : ServiceBasedDespawnStrategy<UnityDestroyService> { }
}