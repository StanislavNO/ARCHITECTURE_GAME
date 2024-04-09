using Assets.Scripts.Infrastructure;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    [RequireComponent(typeof(BoxCollider))]
    public class SaveTrigger : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;

        private ISaveLoadService _saveLoadService;

        private void Awake()
        {
            _collider.isTrigger = true;

            _saveLoadService = ServiceLocator.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            Color color = Color.gray;
            Vector3 position = transform.position + _collider.center;
            Vector3 size = _collider.size;

            color.WithAlpha(50);
            Gizmos.color = color;
            Gizmos.DrawCube(position, size);
        }
    }
}