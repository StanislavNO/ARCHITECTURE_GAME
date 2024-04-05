using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get;}

        bool IsAttackButtonUp();
    }
}
