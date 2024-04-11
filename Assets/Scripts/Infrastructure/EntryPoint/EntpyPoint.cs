using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game.StateMachine.ActivateSate<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}