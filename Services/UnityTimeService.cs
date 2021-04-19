using Gameplay.UnityServices;
using UnityEngine;

namespace Plugins.UnityUtils.Services {
	public class UnityTimeService : IUnityTimeService {
		public float DeltaTime => Time.deltaTime;
		public float FixedDeltaTime => Time.fixedDeltaTime;
	}
}