namespace niscolas.UnityUtils.Core
{
	public class OnDisableEvent : BaseMonoEvent
	{
		private void OnDisable()
		{
			Raise();
		}
	}
}