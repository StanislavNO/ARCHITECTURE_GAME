using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure 
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            GameObject hero = Instantiate("Hero/hero");
        }

        private GameObject Instantiate(string v)
        {
            throw new NotImplementedException();
        }
    }
}