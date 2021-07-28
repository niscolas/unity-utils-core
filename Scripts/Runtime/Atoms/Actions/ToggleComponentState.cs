using niscolas.UnityUtils;
using UnityAtoms;
using UnityEngine;

namespace UnityAtomsUtils.Actions
{
	[CreateAssetMenu(
		menuName = AtomsConstants.ActionsCreateAssetMenuPath + "(Behaviour) => Toggle Enabled State")]
	public class ToggleComponentState : AtomAction<Behaviour>
	{
		public override void Do(Behaviour entry)
		{
			if (!entry)
			{
				return;
			}

			entry.enabled = !entry.enabled;
		}
	}
}