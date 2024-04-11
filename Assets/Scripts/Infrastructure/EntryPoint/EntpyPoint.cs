using UnityEngine;

public class EntryPoint : MonoBehaviour, ICoroutineRunner
{
    private Game _game;

    private void Awake()
    {
        _game = new Game();
        
        DontDestroyOnLoad(this);
    }
}
