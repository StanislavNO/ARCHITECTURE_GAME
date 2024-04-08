using Assets.Scripts.Services.PersistentProgress;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject positionPoint);
        void CreateHud();

        public List<ISavedProgressReader> ProgressReaders { get; }
        public List<ISavedProgress> ProgressWriters { get; }

        void Cleanup();
    }
}