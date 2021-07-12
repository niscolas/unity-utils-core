using UnityEngine;
using UnityExtensions;
using UnityUtils;

namespace niscolas.UnityUtils
{
	public class FaceCamera : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private LifecycleMoment _faceEvent = LifecycleMoment.Update;

		private MonoLifecycle _lifecycle;
		private Transform _cameraTransform;

		private void Start()
		{
			if (!_camera)
			{
				_camera = Camera.main;
				_cameraTransform = _camera.transform;
			}

			_lifecycle = gameObject.IfUnityNullGetOrAddComponent(_lifecycle);
			_lifecycle.AddAction(Do, _faceEvent);
		}

		private void Do()
		{
			transform.forward = _cameraTransform.forward;
		}
	}
}