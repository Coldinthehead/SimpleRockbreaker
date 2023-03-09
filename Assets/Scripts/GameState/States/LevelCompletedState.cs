using Scripts.GameState.Factories;
using Scripts.GameState.Services;

namespace Scripts.GameState.States
{

    public class LevelCompletedState : BaseGameState, IGameState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IPlayerService _playerData;
        public LevelCompletedState(GameStateMachine stateMachine, IUIFactory uiFactory, IPlayerService playerData) : base(stateMachine)
        {
            _uiFactory = uiFactory;
            _playerData = playerData;
        }

        public void Enter()
        {
            _uiFactory.NextLevelMenu.OnNextLevelButtonDown += OnNextLevelButtonDown;

            ShowUI();
            _playerData.CompleteLevel();
            
        }
        public void Exit()
        {
            _uiFactory.NextLevelMenu.OnNextLevelButtonDown -= OnNextLevelButtonDown;
            HideUI();
        }

        private void ShowUI()
        {
            _uiFactory.NextLevelMenu.Show();
            _uiFactory.ResultView.Show();
        }

        private void HideUI()
        {
            _uiFactory.NextLevelMenu.Hide();
            _uiFactory.ResultView.Hide();
        }

        private void OnNextLevelButtonDown()
        {
            _stateMachine.Enter<GameplayState>();
        }


    }
}