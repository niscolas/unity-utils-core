using niscolas.UnityUtils.Core;
using UnityEngine;

namespace UnityUtils
{
    public class Mirror : ExecuteAlwaysMonoBehaviour
    {
        private enum MirrorType
        {
            None,
            Copy,
            Mirror
        }

        [SerializeField]
        private Transform _normalTransform;

        [SerializeField]
        private Transform _mirroredTransform;

        [Header("Position")]
        [SerializeField]
        private MirrorType _positionXMirrorType = MirrorType.Mirror;

        [SerializeField]
        private MirrorType _positionYMirrorType = MirrorType.Copy;

        [SerializeField]
        private MirrorType _positionZMirrorType = MirrorType.Copy;

        [Header("Rotation")]
        [SerializeField]
        private MirrorType _rotationXMirrorType = MirrorType.Copy;

        [SerializeField]
        private MirrorType _rotationYMirrorType = MirrorType.Mirror;

        [SerializeField]
        private MirrorType _rotationZMirrorType = MirrorType.Mirror;

        [Header("Scale")]
        [SerializeField]
        private MirrorType _scaleXMirrorType = MirrorType.Copy;

        [SerializeField]
        private MirrorType _scaleYMirrorType = MirrorType.Copy;

        [SerializeField]
        private MirrorType _scaleZMirrorType = MirrorType.Copy;

        protected override void Inner_Update()
        {
            if (!_normalTransform || !_normalTransform.hasChanged ||
                !_mirroredTransform || !_mirroredTransform.hasChanged)
            {
                return;
            }

            MirrorPosition();
            MirrorRotation();
            MirrorScale();
        }

        private void MirrorPosition()
        {
            _mirroredTransform.localPosition = ComputeMirror(
                _normalTransform.localPosition,
                _mirroredTransform.localPosition,
                _positionXMirrorType,
                _positionYMirrorType,
                _positionZMirrorType);
        }

        private void MirrorRotation()
        {
            _mirroredTransform.localEulerAngles = ComputeMirror(
                _normalTransform.localEulerAngles,
                _mirroredTransform.localEulerAngles,
                _rotationXMirrorType,
                _rotationYMirrorType,
                _rotationZMirrorType);
        }

        private void MirrorScale()
        {
            _mirroredTransform.localScale = ComputeMirror(
                _normalTransform.localScale,
                _mirroredTransform.localScale,
                _scaleXMirrorType,
                _scaleYMirrorType,
                _scaleZMirrorType);
        }

        private Vector3 ComputeMirror(
            Vector3 mirrorTargetValue,
            Vector3 currentMirroredValue,
            MirrorType xMirrorType,
            MirrorType yMirrorType,
            MirrorType zMirrorType)
        {
            float resultX = ComputeMirror(mirrorTargetValue.x, currentMirroredValue.x, xMirrorType);
            float resultY = ComputeMirror(mirrorTargetValue.y, currentMirroredValue.y, yMirrorType);
            float resultZ = ComputeMirror(mirrorTargetValue.z, currentMirroredValue.z, zMirrorType);
            return new Vector3(resultX, resultY, resultZ);
        }

        private float ComputeMirror(float mirrorTargetValue, float currentMirroredValue, MirrorType mirrorType)
        {
            switch (mirrorType)
            {
                case MirrorType.Copy:
                    return mirrorTargetValue;

                case MirrorType.Mirror:
                    return -mirrorTargetValue;

                default:
                    return currentMirroredValue;
            }
        }
    }
}