namespace niscolas.UnityUtils.Core
{
    public interface IUnityTimeService
    {
        float DeltaTime { get; }
        float FixedDeltaTime { get; }
    }
}