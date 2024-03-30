﻿namespace Assets.Scripts.Logic
{
    public interface IAnimationStateReader
    {
        AnimatorState State { get; }

        void EnteredState(int stateHash);
        void ExitedState(int stateHash);
    }
}