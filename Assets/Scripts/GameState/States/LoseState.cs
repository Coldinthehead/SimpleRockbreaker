using Scripts.GameState.Factories;
using Scripts.GameState.Services;

namespace Scripts.GameState.States
{
    public class LoseState : BaseGameState, IGameState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IPlayerService _playerData;
        private readonly IStageService _stageService;
        public LoseState(GameStateMachine stateMachine, IUIFactory uiFactory, IPlayerService playerData, IStageService stageService) : base(stateMachine)
        {
            _uiFactory = uiFactory;
            _playerData = playerData;
            _stageService = stageService;
        }

        public void Enter()
        {
            _uiFactory.LoseMenu.OnMainMenuButtonDown += OnMainMenuButtonDown;
            _uiFactory.LoseMenu.OnRestartButtonDown += OnRestartButtonDown;
            ShowUI();
        }
        public void Exit()
        {
            ResetServices();
            HideUI();
            _uiFactory.LoseMenu.OnMainMenuButtonDown -= OnMainMenuButtonDown;
            _uiFactory.LoseMenu.OnRestartButtonDown -= OnRestartButtonDown;

        }

        private void ShowUI()
        {
            _uiFactory.ResultView.Show();
            _uiFactory.LoseMenu.Show();
        }

        private void ResetServices()
        {
            _playerData.ResetStats();
            _stageService.ResetStage();
        }

        private void HideUI()
        {
            _uiFactory.LoseMenu.Hide();
            _uiFactory.ResultView.Hide();
        }

        private void OnRestartButtonDown()
        {
            _stateMachine.Enter<GameplayState>();
        }

        private void OnMainMenuButtonDown()
        {
            _stateMachine.Enter<MainMenuState>();
        }

    }
}