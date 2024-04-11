using Assets.Scripts.Infrastructure;
using Assets.Scripts.Services.Input;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed = 5f;

        private IInputService _input;
        private Camera _camera;

        private void Awake()
        {
            _input = Game.InputService;
            _controller = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 direction = Vector3.zero;

            if (_input.Axis.sqrMagnitude > Constants.Epsilon)
            {
                direction = _camera.transform.TransformDirection(_input.Axis);
                direction.y = 0;
                direction.Normalize();

                transform.forward = direction;
            }

            direction += Physics.gravity;

            _controller.Move(direction * Time.deltaTime * _speed);
        }
    }
}