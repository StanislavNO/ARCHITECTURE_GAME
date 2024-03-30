using Assets.Scripts.Infrastructure;
using Assets.Scripts.Services.Input;
using Assets.Scripts.Services;
using UnityEngine;
using Assets.Scripts.CameraLogic;

namespace Assets.Scripts.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Start()
        {
            _camera = Camera.main;
            _camera.GetComponent<CameraFollower>().SetTarget(transform); 
        }

        private void Update()
        {
            Vector3 direction = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                direction = _camera.transform
                    .TransformDirection(_inputService.Axis);

                direction.y = 0;
                direction.Normalize();

                transform.forward = direction;
            }

            direction += Physics.gravity;

            _characterController.Move(direction * Time.deltaTime * _speed);
        }
    }
}