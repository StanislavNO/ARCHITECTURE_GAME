using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure;

namespace Assets.Scripts.Services
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}