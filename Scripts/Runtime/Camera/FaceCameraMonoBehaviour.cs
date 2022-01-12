using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Face Camera")]
    [DisallowMultipleComponent]
    public class FaceCameraMonoBehaviour : AutoTriggerMonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        private MonoHooksManagerMonoBehaviour _lifecycle;
        private Transform _cameraTransform;

        protected override void Awake()
        {
            base.Awake();

            if (!_camera)
            {
                _camera = Camera.main;
                _cameraTransform = _camera.transform;
            }
        }

        public override void Do()
        {
            _transform.LookAt(_cameraTransform);
        }
    }
}