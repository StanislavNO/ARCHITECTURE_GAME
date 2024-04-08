using Assets.Scripts.Services.PersistentProgress;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;

            ProgressReaders = new();
            ProgressWriters = new();
        }

        public List<ISavedProgressReader> ProgressReaders { get; private set; }
        public List<ISavedProgress> ProgressWriters { get; private set; }

        public GameObject CreateHero(GameObject positionPoint)
        {
            return InstantiateRegistered(
                AssetPath.PlayerPath,
                positionPoint.transform.position);
        }

        public void CreateHud()
        {
            InstantiateRegistered(AssetPath.HudPath);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assetProvider.Instantiate(prefabPath);

            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assetProvider.Instantiate(prefabPath, at);

            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            ISavedProgressReader[] readers = gameObject.GetComponentsInChildren<ISavedProgressReader>();

            foreach (ISavedProgressReader reader in readers)
            {
                Register(reader);
            }
        }

        private void Register(ISavedProgressReader reader)
        {
            ProgressReaders.Add(reader);

            if (reader is ISavedProgress writer)
                ProgressWriters.Add(writer);
        }
    }
}