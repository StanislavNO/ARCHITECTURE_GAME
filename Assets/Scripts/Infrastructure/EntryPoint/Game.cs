using Assets.Scripts.Services.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {

        public Game()
        {
            StateMachine = new GameStateMachine();
        }

        public GameStateMachine StateMachine { get; private set; }
        public static IInputService InputService { get; private set; }

        public static void SetInputService(IInputService inputService)
        {
            InputService = inputService;
        }
    }
}