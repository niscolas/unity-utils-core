using niscolas.UnityUtils;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityUtils
{
	[CreateAssetMenu(menuName = AtomsConstants.ActionsCreateAssetMenuPath + "(GameObject) => Despawn")]
	public class DespawnGameObject : AtomAction<GameObject>
	{
		[SerializeField]
		private FloatReference _delay;

		[SerializeField]
		private DespawnStrategy _strategy;

		public override void Do(GameObject gameObject)
		{
			_strategy.Despawn(gameObject, _delay.Value);
		}
	}
}