using Scripts.GameState.Factories;
using Scripts.GameState.Services;

namespace Scripts.GameState.States
{
    public class GameplayState : BaseGameState, IGameState
    {
        private readonly IGameFactory _gameFactory;
        private readonly IPlayerService _playerData;
        private readonly IUIFactory _uiFactory;
        private readonly IStageService _stargeService;
        private LevelState _currentLevelState;

        public GameplayState(GameStateMachine stateMachine, IGameFactory gameFactory,
            IPlayerService playerData, IUIFactory uiFactory, IStageService strages) : base(stateMachine)
        {
            _gameFactory = gameFactory;
            _playerData = playerData;
            _uiFactory = uiFactory;
            _stargeService = strages;
        }

        public void Enter()
        {
            UpdateCurrentLevelState();
            BindEvents();
            StartLevel();
            ShowUI();
        }
        public void Exit()
        {
            PauseLevelState();
            UnbindEvents();
            HideUI();
        }

        private void UpdateCurrentLevelState()
        {
            _currentLevelState = _gameFactory.LevelState;
        }

        private void BindEvents()
        {
            _playerData.OnLifesEnded += OnLifesEnded;

            _currentLevelState.OnBallMissed += OnBallMissed;
            _currentLevelState.OnBlockDestroyed += OnBlockDestroyed;

            _stargeService.OnStageCompleted += OnStageCompleted;
            _stargeService.OnLevelCompleted += OnLevelCompleted;
        }

        private void StartLevel()
        {
            _stargeService.StartLevel();
            _currentLevelState.StartLevel(_gameFactory.CreateBlockForCurrentLevel());

            _currentLevelState.NormalizeTime();
        }

        private void ShowUI()
        {
            _uiFactory.ScoreUI.Show();
        }

        private void PauseLevelState()
        {
            _currentLevelState.ClearBlocks();
            _currentLevelState.SlowTime();
        }

        private void UnbindEvents()
        {
            _playerData.OnLifesEnded -= OnLifesEnded;

            _currentLevelState.OnBallMissed -= OnBallMissed;
            _currentLevelState.OnBlockDestroyed -= OnBlockDestroyed;

            _stargeService.OnStageCompleted -= OnStageCompleted;
            _stargeService.OnLevelCompleted -= OnLevelCompleted;

        }

        private void HideUI()
        {
            _uiFactory.ScoreUI.Hide();
            _uiFactory.ComboView.Hide();
        }

        private void OnLifesEnded()
        {
            _stateMachine.Enter<LoseState>();
        }

        private void OnBallMissed()
        {
            _playerData.RemoveLife();
        }

        private void OnBlockDestroyed(BlockState args)
        {
            _playerData.ScoreCounter.OnBallDestroyed();
            CheckForWin(args.LeftAlive);
        }

        private void OnLevelCompleted()
        {
            _stateMachine.Enter<LevelCompletedState>();
        }

        private void OnStageCompleted()
        {
            _stateMachine.Enter<StageCompletedState>();
        }

        private void CheckForWin(int remaining)
        {
            if (remaining <= 0)
                _stargeService.CompleteLevel();
        }
    }
}