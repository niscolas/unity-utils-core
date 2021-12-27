using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class FaceCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private MonoCallbackType _faceEvent = MonoCallbackType.Update;

        private Transform _cameraTransform;

        private MonoLifecycleHooksManager _lifecycle;

        private void Awake()
        {
            if (!_camera)
            {
                _camera = Camera.main;
                _cameraTransform = _camera.transform;
            }

            MonoLifecycleHooksManager.AutoTrigger(gameObject, Do, _faceEvent);
        }

        private void Do()
        {
            transform.LookAt(_cameraTransform);
        }
    }
}