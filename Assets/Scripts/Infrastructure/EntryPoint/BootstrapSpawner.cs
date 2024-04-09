using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EntryPoint
{
    public class BootstrapSpawner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _prefab;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();

            if (bootstrapper == null)
                Instantiate(_prefab);
        }
    }
}