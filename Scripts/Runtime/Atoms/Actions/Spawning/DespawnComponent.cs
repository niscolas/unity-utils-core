using niscolas.UnityUtils;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityUtils
{
	[CreateAssetMenu(menuName = AtomsConstants.ActionsCreateAssetMenuPath + "(Component) => Despawn")]
	public class DespawnComponent : AtomAction<Component>
	{
		[SerializeField]
		private FloatReference _delay;

		[SerializeField]
		private DespawnStrategy _strategy;

		public override void Do(Component component)
		{
			_strategy.Despawn(component, _delay.Value);
		}
	}
}