using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Core
{
    public class BaseMonoEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _events;

        public UnityEvent Events => _events;

        protected void Raise()
        {
            _events?.Invoke();
        }
    }
}