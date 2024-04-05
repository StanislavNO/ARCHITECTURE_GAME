using Assets.Scripts.Infrastructure;
using Assets.Scripts.Services.Input;
using Assets.Scripts.Services;
using UnityEngine;
using Assets.Scripts.Services.PersistentProgress;
using Assets.Scripts.Data;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed = 5f;

        private IInputService _input;
        private Camera _camera;

        private void Awake()
        {
            _input = ServiceLocator.Container.Single<IInputService>();
            _characterController = GetComponent<CharacterController>();
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

            _characterController.Move(direction * Time.deltaTime * _speed);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel = new PositionOnLevel(
                GetCurrentLevel(),
                DataExtensions.AsVectorData(transform.position));
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (GetCurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savePosition = progress.WorldData.PositionOnLevel.Position;

                if (savePosition != null)
                    Warp(to: savePosition);
            }
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = DataExtensions.AsUnityVector(to);
            _characterController.enabled = true;
        }

        private string GetCurrentLevel()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}