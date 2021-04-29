using System;

namespace UnityUtils
{
	public interface ILifecycleSubject
	{
		event Action OnAwake;
		event Action OnEnabled;
		event Action OnStarted;
		event Action OnDisabled;
		event Action OnDestroyed;
	}
}