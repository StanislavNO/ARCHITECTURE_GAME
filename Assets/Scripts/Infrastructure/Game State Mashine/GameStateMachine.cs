using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }

        public void Exit()
        {

        }
    }
}