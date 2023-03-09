using Scripts.GameState.Factories;

namespace Scripts.GameState.States
{
    public class StageCompletedState : BaseGameState , IGameState
    {
        private readonly IUIFactory _uiFactory;
        public StageCompletedState(GameStateMachine stateMachine, IUIFactory uiFactory) : base(stateMachine)
        {
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _uiFactory.WinMenu.OnMainMenuButtonDown += OnMainMenuButtonDown;

            _uiFactory.ResultView.Show();
            _uiFactory.WinMenu.Show();
        }

        private void OnMainMenuButtonDown()
        {
            _stateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
            _uiFactory.ResultView.Hide();
            _uiFactory.WinMenu.Hide();
            _uiFactory.WinMenu.OnMainMenuButtonDown -= OnMainMenuButtonDown;
        }
    }
}