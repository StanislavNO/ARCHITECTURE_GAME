using Assets.Scripts.Services.Input;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService { get; private set; }

        public Game()
        {
            RegisterInputService();
        }

        private static void RegisterInputService()
        {
            if (Application.isEditor)
                InputService = new StandaloneInputService();
            else
                InputService = new MobileInputService();
        }
    }
}