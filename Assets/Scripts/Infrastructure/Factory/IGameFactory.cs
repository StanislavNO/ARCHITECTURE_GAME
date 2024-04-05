using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject positionPoint);
        void CreateHud();
    }
}