using UnityEngine;

namespace UnityUtils
{
	public class UnityTimeService : IUnityTimeService
	{
		public float DeltaTime => Time.deltaTime;
		public float FixedDeltaTime => Time.fixedDeltaTime;
	}
}