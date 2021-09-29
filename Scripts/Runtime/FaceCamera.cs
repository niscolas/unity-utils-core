using UnityEngine;
using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;
using UnityUtils;

namespace niscolas.UnityUtils
{
    public class FaceCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private LifecycleMoment _faceEvent = LifecycleMoment.Update;

        private MonoLifeCycle _lifecycle;
        private Transform _cameraTransform;

        private void Awake()
        {
            if (!_camera)
            {
                _camera = Camera.main;
                _cameraTransform = _camera.transform;
            }

            MonoLifeCycle.TriggerOnMoment(gameObject, Do, _faceEvent);
        }

        private void Do()
        {
            transform.LookAt(_cameraTransform);
        }
    }
}