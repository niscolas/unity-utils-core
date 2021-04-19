namespace UnityAtomsUtils.MonoBehaviourHelpers.MonoEvents
{
	public class AwakeEvents : BaseMonoEvents
	{
		private void Awake()
		{
			Raise();
		}
	}
}