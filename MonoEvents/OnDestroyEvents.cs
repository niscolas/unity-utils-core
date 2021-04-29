namespace UnityUtils
{
	public class OnDestroyEvents : BaseMonoEvents
	{
		private void OnDestroy()
		{
			Raise();
		}
	}
}