namespace niscolas.UnityUtils.Core
{
	public class OnDestroyEvent : BaseMonoEvent
	{
		private void OnDestroy()
		{
			Raise();
		}
	}
}