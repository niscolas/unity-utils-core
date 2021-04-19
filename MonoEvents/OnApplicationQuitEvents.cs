namespace UnityAtomsUtils.MonoBehaviourHelpers.MonoEvents
{
	public class OnApplicationQuitEvents : BaseMonoEvents
	{
		private void OnApplicationQuit()
		{
			Raise();
		}
	}
}