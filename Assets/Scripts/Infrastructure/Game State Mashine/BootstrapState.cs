using Assets.Scripts.Services.Input;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            RegisterServices();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        private void RegisterServices()
        {
            Game.SetInputService(RegisterInputService());
        }

        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
            {
                return new MobileInputService();
            }
        }
    }
}
