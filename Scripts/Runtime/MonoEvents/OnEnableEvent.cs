namespace niscolas.UnityUtils.Core
{
	public class OnEnableEvent : BaseMonoEvent
	{
		private void OnEnable()
		{
			Raise();
		}
	}
}