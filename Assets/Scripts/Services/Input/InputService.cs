﻿using UnityEngine;

namespace Assets.Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string Attack = "Attack";

        public abstract Vector2 Axis { get;}

        public bool IsAttackButtonUp()
        {
            return SimpleInput.GetButtonUp(Attack);
        }

        protected Vector2 GetSimpleInputAxis()
        {
            Vector2 Axis = new Vector2(
                SimpleInput.GetAxis(Horizontal),
                SimpleInput.GetAxis(Vertical));

            return Axis;
        }
    }
}