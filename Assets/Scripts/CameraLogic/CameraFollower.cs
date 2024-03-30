using UnityEngine;

namespace Assets.Scripts.CameraLogic
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _distance;
        [SerializeField] private float _rotationX;
        [SerializeField] private float _offsetY;

        private void LateUpdate()
        {
            if (_target == null)
                return;

            Quaternion rotation = Quaternion.Euler(
                Vector3.right * _rotationX);

            Vector3 position =
                rotation * (Vector3.forward * -(_distance))
                + GetTargetPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private Vector3 GetTargetPointPosition()
        {
            Vector3 targetPosition;

            targetPosition = _target.position;
            targetPosition.y += _offsetY;

            return targetPosition;
        }
    }
}