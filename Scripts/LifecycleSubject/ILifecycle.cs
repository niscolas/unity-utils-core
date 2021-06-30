using System;

namespace UnityUtils
{
	public interface ILifecycle
	{
		event Action OnAwake;
		event Action OnEnabled;
		event Action OnStart;
		event Action OnDisabled;
		event Action OnDestroyed;
	}
}