using Scripts.Data;
using Scripts.GameState.Services;
using UnityEngine;

namespace Scripts.GameState.Factories
{
    public class GameFactory : IGameFactory
    {
        public Paddle Paddle { get; private set; }
        public Ball Ball { get; private set; }
        public LevelState LevelState { get; private set; }

        public BackgroundChanger Background { get; set; }

        private readonly IStageService _stageService;
        private readonly IPlayerService _playerService;
        public GameFactory(IStageService stages, IPlayerService playerService)
        {
            _stageService = stages;
            _playerService = playerService;
        }

        public BackgroundChanger CreateBackground(GameObject gameObject)
        {
            Background = gameObject.GetComponent<BackgroundChanger>();
            Background.Construct(_stageService);
            return Background;
        }

        public Paddle CreatePaddle(Transform initialPoint)
        {
            string path = "Gameplay/Paddle";
            GameObject prefab = Resources.Load(path) as GameObject;

            Paddle = Object.Instantiate(prefab).GetComponent<Paddle>();
            Paddle.transform.position = initialPoint.position;
            return Paddle;
        }
        public Ball CreateBall()
        {
            string path = "Gameplay/Ball";
            GameObject prefab = Resources.Load(path) as GameObject;

            Ball = Object.Instantiate(prefab).GetComponent<Ball>();
            return Ball;
        }

        public LevelState CreateLevelState(LoseTrigger loseTrigger, GameObject initialiPoint)
        {
            LevelState = new LevelState(loseTrigger, Paddle, Ball, initialiPoint.transform.position);
            return LevelState;
        }

        public BlockHolder CreateBlockForCurrentLevel()
        {
            return Object.Instantiate(_stageService.CurrentLevel.BlocksPattern);
        }
        public void InitPlayer()
        {
            _playerService.ScoreCounter = new ComboScoreCounter(_playerService.PlayerData);
        }
        public void Clearup()
        {
            Paddle = null;
            Ball = null;
            Background = null;
            LevelState = null;
        }


    }
}