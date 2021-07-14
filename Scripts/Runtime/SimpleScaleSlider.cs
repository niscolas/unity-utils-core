using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils
{
	public class SimpleScaleSlider : MonoBehaviour
	{
		[SerializeField]
		private Transform _fillTransform;

		[SerializeField]
		private FloatReference _fullValue = new FloatReference(1);

		[SerializeField]
		private FloatReference _fullScale = new FloatReference(1);

		[SerializeField]
		private ScaleAxis _affectedAxis;

		private void Start()
		{
			if (!_fillTransform)
			{
				_fillTransform = transform;
			}
		}

		public void SetFill(float ratio)
		{
			float fill = _fullScale * ratio;

			Vector3 currentLocalScale = _fillTransform.localScale;
			switch (_affectedAxis)
			{
				case ScaleAxis.X:
					currentLocalScale.x = fill;
					break;

				case ScaleAxis.Y:
					currentLocalScale.y = fill;
					break;

				case ScaleAxis.Z:
					currentLocalScale.z = fill;
					break;
			}

			_fillTransform.localScale = currentLocalScale;
		}

		public void SetFillRaw(float raw)
		{
			float relativeFill = raw / _fullValue.Value;
			SetFill(relativeFill);
		}

		private enum ScaleAxis
		{
			X,
			Y,
			Z
		}
	}
}