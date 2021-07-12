using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace niscolas.UnityUtils
{
	public class SimpleDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField]
		private RectTransform _targetRectTransform;

		[SerializeField]
		private float _zOffset;

		[SerializeField]
		private bool _resetPositionOnEnd;

		[Header("Events")]
		[SerializeField]
		private UnityEvent _onBeginDrag;

		[SerializeField]
		private UnityEvent _onEndDrag;

		public RectTransform TargetRectTransform => _targetRectTransform;

		public UnityEvent BeganDrag => _onBeginDrag;

		public UnityEvent EndedDrag => _onEndDrag;

		private Canvas _canvas;
		private Mouse _mouse;
		private Transform _dragStartParent;
		private Vector3 _dragStartPosition;
		private float _currentDragZOffset;

		private void Start()
		{
			if (!_targetRectTransform)
			{
				TryGetComponent(out _targetRectTransform);
			}

			_canvas = GetComponentInParent<Canvas>();
			_mouse = Mouse.current;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			_dragStartPosition = _targetRectTransform.position;
			_dragStartParent = _targetRectTransform.parent;
			_currentDragZOffset = _targetRectTransform.position.z + _zOffset;

			_targetRectTransform.SetParent(_canvas.transform);

			_onBeginDrag?.Invoke();
		}

		public void OnDrag(PointerEventData eventData)
		{
			FollowMouse();
		}

		private void FollowMouse()
		{
			Vector3 mousePosition = _mouse.position.ReadValue();
			mousePosition.z = _currentDragZOffset;

			_targetRectTransform.position = mousePosition;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			_onEndDrag?.Invoke();

			_targetRectTransform.SetParent(_dragStartParent);

			if (_resetPositionOnEnd)
			{
				_targetRectTransform.position = _dragStartPosition;
			}
		}
	}
}