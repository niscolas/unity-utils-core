using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Face Camera")]
    [DisallowMultipleComponent]
    public class FaceCameraMB : AutoTriggerMB
    {
        [SerializeField]
        private Camera _camera;

        private MonoHooksManagerMB _lifecycle;
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