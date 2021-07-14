namespace UnityUtils
{
	public class OnEnableEvents : BaseMonoEvents
	{
		private void OnEnable()
		{
			Raise();
		}
	}
}