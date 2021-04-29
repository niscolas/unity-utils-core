namespace UnityUtils
{
	public class OnDisableEvents : BaseMonoEvents
	{
		private void OnDisable()
		{
			Raise();
		}
	}
}