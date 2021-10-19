using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class CachedMonoBehaviour : MonoBehaviour
    {
        protected GameObject _gameObject;
        protected Transform _transform;

        protected virtual void Awake()
        {
            _gameObject = gameObject;
            _transform = transform;
        }
    }
}