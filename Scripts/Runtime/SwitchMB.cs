using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Switch")]
    public class SwitchMB : CachedMonoBehaviour
    {
        [SerializeField]
        private bool _currentState;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onEnabled;

        [SerializeField]
        private UnityEvent _onDisabled;

        [SerializeField]
        private UnityEvent<bool> _onStateChanged;

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

            _onStateChanged?.Invoke(_currentState);
        }
    }
}