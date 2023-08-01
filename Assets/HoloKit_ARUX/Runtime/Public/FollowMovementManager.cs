using UnityEngine;

namespace Holoi.Library.ARUX
{
    public class FollowMovementManager : MonoBehaviour
    {
        enum MovementType
        {
            HardFollow,
            SoftFollow,
            NotFollow
        }

        enum RotateType
        {
            None,
            FacingTargetInvert,
            FacingTarget,
            IdenticalToTarget,
            FacingTargetHorizentally
        }

        [SerializeField] private Transform _followTarget;

        public Transform FollowTarget
        {
            set
            {
                _followTarget = value;
            }
        }

        [Header("Transform")]
        [SerializeField] MovementType _movementType;

        [Header("Rotation")]
        [SerializeField] RotateType _rotateType;
        [SerializeField] Vector3 _axisWeight = Vector3.one;

        [Header("Offset & Space")]
        [SerializeField] bool _worldSpace = false;

        [SerializeField] private Vector3 _offset = new Vector3(0, 0, 0.5f);

        [Header("Movement")]
        [SerializeField] private float _lerpSpeed = 4f;

        [SerializeField] private float _chaseDistance = .01f;

        [SerializeField] private float _reachDistance = .001f;

        [SerializeField] AnimationCurve _lerpCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

        bool _needMove = false;

        public Vector3 Offset
        {
            set
            {
                _offset = value;
            }
            get
            {
                return _offset;
            }
        }

        Vector3 targetPosition;

        void Start()
        {
            if (_followTarget == null) { return; }
        }

        void FixedUpdate()
        {
            if (_followTarget == null) { return; }
            UpdatePosition();
            UpdateRotation();
        }

        void UpdatePosition()
        {
            switch (_movementType)
            {
                case MovementType.HardFollow:
                    targetPosition = GetTargetPosition(_followTarget.position, _offset);
                    transform.position = targetPosition;
                    break;
                case MovementType.SoftFollow:
                    targetPosition = GetTargetPosition(_followTarget.position, _offset);
                    if (Vector3.Distance(targetPosition, transform.position) > _chaseDistance)
                    {
                        _needMove = true;
                    }
                    if (_needMove)
                    {
                        transform.position = Vector3.Scale(PositionAnimationLerp(transform.position, targetPosition, _lerpSpeed), _axisWeight);
                        if (Vector3.Distance(_followTarget.position, transform.position) < _reachDistance)
                        {
                            _needMove = false;
                        }
                    }
                    break;
                case MovementType.NotFollow:

                    break;
            }
        }

        void UpdateRotation()
        {
            switch (_rotateType)
            {
                case RotateType.FacingTargetInvert:
                    transform.rotation = Quaternion.Euler(_followTarget.rotation.eulerAngles.x, _followTarget.rotation.eulerAngles.y, _followTarget.rotation.eulerAngles.z);
                    break;
                case RotateType.FacingTarget:
                    transform.LookAt(_followTarget);
                    break;
                case RotateType.None:
                    break;
                case RotateType.IdenticalToTarget:
                    transform.rotation = _followTarget.rotation;
                    break;
                case RotateType.FacingTargetHorizentally:
                    var pos = new Vector3(_followTarget.position.x, transform.position.y, _followTarget.position.z);
                    transform.LookAt(pos);
                    break;
            }
        }

        Vector3 PositionAnimationLerp(Vector3 position, Vector3 targetPosition, float lerpSpeed)
        {
            var m = Vector3.Distance(targetPosition, position)/_chaseDistance;
            if (m > 1)
            {
                m = 1;
            }
            else
            {
                m = _lerpCurve.Evaluate(m);
            }

            position += (targetPosition - position) * Time.deltaTime * lerpSpeed;

            return position;
        }

        Vector3 GetTargetPosition(Vector3 targetPosition, Vector3 offset)
        {
            var localOffset = _followTarget.TransformVector(_offset);
            var worldOffset = offset;

            if (_worldSpace)
            {
                return targetPosition + worldOffset;
            }
            else
            {
                return targetPosition + localOffset;
            }
        }
    }
}