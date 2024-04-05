using Assets.Scripts.Data;

namespace Assets.Scripts.Infrastructure
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}
