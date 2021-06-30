using System;

namespace UnityUtils
{
	public class TickSystem
	{
		private readonly Action _action;
		private readonly float _intervalSec;
		private bool _running;

		private TickSystem(Action action, float intervalSec)
		{
			_action = action;
			_intervalSec = intervalSec;
		}

		public static TickSystem New(Action action, float intervalSec)
		{
			TickSystem tickSystem = new TickSystem(action, intervalSec);

			return tickSystem;
		}

		public static TickSystem StartNew(Action action, float intervalSec)
		{
			TickSystem tickSystem = New(action, intervalSec);
			tickSystem.Start();

			return tickSystem;
		}

		public async void Start()
		{
			if (_running) return;

			_running = true;
			while (true)
			{
				await Wait.Seconds(_intervalSec);
				
				if (!_running) break;

				DoTick();
			}
		}

		private void DoTick()
		{
			_action?.Invoke();
		}

		public void Stop()
		{
			_running = false;
		}
	}
}