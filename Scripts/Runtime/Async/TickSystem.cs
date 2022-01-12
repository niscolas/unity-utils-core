using System;
using Cysharp.Threading.Tasks;

namespace niscolas.UnityUtils.Core
{
    public class TickSystem
    {
        public struct Data
        {
            public float ElapsedTime;
            public int TickCount;

            public Data(float elapsedTime, int tickCount)
            {
                ElapsedTime = elapsedTime;
                TickCount = tickCount;
            }
        }

        private readonly Action<Data> _tickCallback;
        private readonly Action<Data> _stoppedCallback;
        private readonly float _intervalSeconds;

        private Data _data;
        private bool _running;

        public TickSystem(
            float intervalSeconds,
            Action<Data> tickCallback,
            Action<Data> stoppedCallback = null)
        {
            _intervalSeconds = intervalSeconds;

            _tickCallback = tickCallback;
            _stoppedCallback = stoppedCallback;

            _data = new Data();
            _running = false;
        }

        public static TickSystem StartNew(
            float intervalSeconds,
            Action<Data> tickCallback,
            Action<Data> stoppedCallback = null)
        {
            TickSystem tickSystem = new TickSystem(
                intervalSeconds, tickCallback, stoppedCallback);
            tickSystem.Start();

            return tickSystem;
        }

        public void Start()
        {
            StartAsync().Forget();
        }

        private async UniTaskVoid StartAsync()
        {
            if (_running)
            {
                return;
            }

            ResetState();

            while (true)
            {
                await Await.Seconds(_intervalSeconds);

                if (!_running)
                {
                    break;
                }

                IncrementData();

                DoTick();
            }
        }

        private void ResetState()
        {
            _data.ElapsedTime = 0;
            _data.TickCount = 0;
            _running = true;
        }

        private void IncrementData()
        {
            _data.ElapsedTime += _intervalSeconds;
            _data.TickCount++;
        }

        private void DoTick()
        {
            _tickCallback?.Invoke(_data);
        }

        public void Stop()
        {
            _running = false;
            _stoppedCallback?.Invoke(_data);
        }
    }
}