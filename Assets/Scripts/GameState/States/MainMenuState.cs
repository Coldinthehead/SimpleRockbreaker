using Scripts.GameState.Factories;

namespace Scripts.GameState.States
{
    public class MainMenuState : BaseGameState, IGameState
    {
        private readonly IUIFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;
        public MainMenuState(GameStateMachine stateMachine, IUIFactory uiFactory, SceneLoader sceneLoader) : base(stateMachine)
        {
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene("MainMenuScene", OnLoaded);
        }

        private void OnLoaded()
        {
            _uiFactory.Clearup();
            _uiFactory.CreateMainMenu();
            _uiFactory.MainMenu.OnNewGameButtonDown += StartNewGame;
        }

        private void StartNewGame()
        {
            _stateMachine.Enter<LoadPlayerProgressState>();
        }

        public void Exit()
        {
            _uiFactory.MainMenu.OnNewGameButtonDown -= StartNewGame;
        }
    }
}