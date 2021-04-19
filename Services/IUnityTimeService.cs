namespace Gameplay.UnityServices {
	public interface IUnityTimeService {
		float DeltaTime { get; }
		float FixedDeltaTime { get; }
	}
}