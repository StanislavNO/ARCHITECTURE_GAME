using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateHero(GameObject positionPoint)
        {
            return _assetProvider.Instantiate(
                AssetPath.PlayerPath,
                positionPoint.transform.position);
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }
    }
}