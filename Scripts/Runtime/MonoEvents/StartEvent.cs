namespace niscolas.UnityUtils.Core
{
	public class StartEvent : BaseMonoEvent
	{
		private void Start()
		{
			Raise();
		}
	}
}