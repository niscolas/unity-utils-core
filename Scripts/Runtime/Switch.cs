using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Core
{
    public class Switch : CachedMonoBehaviour
    {
        [SerializeField]
        private bool _currentState;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onEnabled;

        [SerializeField]
        private UnityEvent _onDisabled;

        [SerializeField]
        private UnityEvent<bool> _onStateSet;

        public void Toggle()
        {
            SetState(!_currentState);
        }

        public void SetState(bool value)
        {
            _currentState = value;
            if (value)
            {
                _onEnabled?.Invoke();
            }
            else
            {
                _onDisabled?.Invoke();
            }
            _onStateSet?.Invoke(_currentState);
        }
    }
}