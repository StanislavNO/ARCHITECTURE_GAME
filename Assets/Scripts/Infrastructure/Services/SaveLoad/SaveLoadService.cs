using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure;
using Assets.Scripts.Services;
using Assets.Scripts.Services.PersistentProgress;
using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private const string ProgressKey = "Progress";

    private readonly IGameFactory _gameFactory;
    private readonly IPersistentProgressService _progressService;

    public SaveLoadService(IPersistentProgressService progressService ,IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;
        _progressService = progressService;
    }

    public PlayerProgress LoadProgress()
    {
        return PlayerPrefs.GetString(ProgressKey)
            ?.ToDeserialised<PlayerProgress>();
    }

    public void SaveProgress()
    {
        foreach(ISavedProgress writer in _gameFactory.ProgressWriters)
        {
            writer.UpdateProgress(_progressService.Progress);
        }

        PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
    }
}
