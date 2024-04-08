using Assets.Scripts.Services;
using Assets.Scripts.Services.Input;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string EntryPoint = "EntryPoint";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _serviceLocator;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator serviceLocator)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _serviceLocator = serviceLocator;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(EntryPoint, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadProgressState>();
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterSingle(GetInputService());
            _serviceLocator.RegisterSingle<IAssetProvider>(new AssetProvider());
            _serviceLocator.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _serviceLocator.RegisterSingle<IGameFactory>(new GameFactory(_serviceLocator.Single<IAssetProvider>()));
            _serviceLocator.RegisterSingle<ISaveLoadService>(new SaveLoadService(_serviceLocator.Single<IPersistentProgressService>(), _serviceLocator.Single<IGameFactory>()));
        }


        private IInputService GetInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}