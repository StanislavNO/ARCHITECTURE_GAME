using Assets.Scripts.Logic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _prefab;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _prefab);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}