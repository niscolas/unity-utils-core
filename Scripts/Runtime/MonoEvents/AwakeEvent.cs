namespace niscolas.UnityUtils.Core
{
	public class AwakeEvent : BaseMonoEvent
	{
		private void Awake()
		{
			Raise();
		}
	}
}