using Assets.Scripts.Services.Input;
using Assets.Scripts.Logic;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, ServiceLocator.Container);
        }
    }
}