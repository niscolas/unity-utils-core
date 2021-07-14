namespace UnityUtils
{
	public interface IUnityTimeService
	{
		float DeltaTime { get; }
		float FixedDeltaTime { get; }
	}
}