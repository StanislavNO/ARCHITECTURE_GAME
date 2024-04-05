using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure;
using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private const string ProgressKey = "Progress";

    public PlayerProgress LoadProgress()
    {
        return PlayerPrefs.GetString(ProgressKey)?
            .ToDeserialised<PlayerProgress>();
    }

    public void SaveProgress()
    {
    }
}
