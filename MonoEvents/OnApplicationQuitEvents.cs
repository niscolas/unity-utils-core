namespace UnityUtils
{
	public class OnApplicationQuitEvents : BaseMonoEvents
	{
		private void OnApplicationQuit()
		{
			Raise();
		}
	}
}