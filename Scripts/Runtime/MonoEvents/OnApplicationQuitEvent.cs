namespace niscolas.UnityUtils.Core
{
	public class OnApplicationQuitEvent : BaseMonoEvent
	{
		private void OnApplicationQuit()
		{
			Raise();
		}
	}
}