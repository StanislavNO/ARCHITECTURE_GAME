using Assets.Scripts.CameraLogic;
using Assets.Scripts.Logic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitPointTag = "initialPoint";
        private const string PlayerPath = "Hero/hero";
        private const string HudPath = "HUD/HeadUpDisplay";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curain.Hide();
        }

        private void OnLoaded()
        {
            var initPoint = GameObject.FindWithTag(InitPointTag);
            GameObject hero = Instantiate(PlayerPath, initPoint.transform.position);
            Instantiate(HudPath);

            CameraFollow(hero);

            _stateMachine.Enter<GameLoopState>();
        }

        private static void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollower>()
                .SetTarget(hero.transform);
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);

            return GameObject.Instantiate(prefab);
        }

        private static GameObject Instantiate(string path, Vector3 position)
        {
            var prefab = Resources.Load<GameObject>(path);

            return GameObject.Instantiate(prefab, position, Quaternion.identity);
        }

    }
}