using Scripts.GameState.Factories;
using UnityEngine;

namespace Scripts.GameState.States
{

    public class BuildLevelState : BaseGameState, IGameState
    {
        private const string GameSceneName = "GameplayScene";
        private const string PaddlePointTag = "PaddleInitialPoint";
        private const string BackgroundChangerTag = "BackgroundChanger";
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uIFactory;

        public BuildLevelState(GameStateMachine stateMachine,
            SceneLoader sceneLoader, IGameFactory gameFactory,IUIFactory uIFactory) : base(stateMachine)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uIFactory = uIFactory;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(GameSceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            BuildLevel();
            CreateUI();

            _stateMachine.Enter<GameplayState>();
        }

        private void BuildLevel()
        {
            _gameFactory.Clearup();
            _gameFactory.InitPlayer();

            GameObject paddleInitialPoint = GameObject.FindGameObjectWithTag(PaddlePointTag);
            LoseTrigger loseTrigger = Object.FindObjectOfType<LoseTrigger>();
            _gameFactory.CreateBackground(GameObject.FindGameObjectWithTag(BackgroundChangerTag));

            _gameFactory.CreateBall();
            _gameFactory.CreatePaddle(paddleInitialPoint.transform);
            _gameFactory.CreateLevelState(loseTrigger, paddleInitialPoint);


        }

        private void CreateUI()
        {
            _uIFactory.Clearup();
            _uIFactory.CreateNextLevelMenu();
            _uIFactory.CreateLoseMenu();
            _uIFactory.CreateScoreUI();
            _uIFactory.CreateResultView();
            _uIFactory.CreateWinMenu();
            _uIFactory.CreateComboView();
        }

        public void Exit()
        {
            
        }
    }
}