using Assets.Scripts.Services.Input;
using Assets.Scripts.Logic;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        private IInputService _inputService;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, ServiceLocator.Container);
        }

        public GameStateMachine StateMachine { get; private set; }
    }
}