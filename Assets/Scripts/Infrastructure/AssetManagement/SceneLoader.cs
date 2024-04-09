using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts.Infrastructure
{
    public class SceneLoader
    {
        private ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                Debug.Log("s");
                onLoaded?.Invoke();
                yield break;
            }
            Debug.Log("ss");
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}