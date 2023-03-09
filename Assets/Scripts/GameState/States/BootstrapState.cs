using Scripts.Data;
using Scripts.GameState.Factories;
using Scripts.GameState.Services;

namespace Scripts.GameState.States
{

    public class BootstrapState : BaseGameState, IGameState
    {
        private readonly ServiceLocator _servicesContainer;
        private readonly SceneLoader _sceneLoader;
        private readonly StageTemplate _stages;
        public BootstrapState(GameStateMachine stateMachine, ServiceLocator servicesContainer
            , SceneLoader sceneLoader, StageTemplate stages) : base(stateMachine)
        {
            _stages = stages;
            _servicesContainer = servicesContainer;
            _sceneLoader = sceneLoader;
            RegisterServices();

        }

        private void RegisterServices()
        {
            _servicesContainer.Register<IStageService>(new StageService(_stages));
            _servicesContainer.Register<IPlayerService>(new PlayerDataService());
            _servicesContainer.Register<IUIFactory>(new UiFactory(_servicesContainer.Single<IPlayerService>()));

            _servicesContainer.Register<IGameFactory>(new GameFactory(
                _servicesContainer.Single<IStageService>(),_servicesContainer.Single<IPlayerService>()));

        }

        public void Enter()
        {
            _sceneLoader.LoadScene("BootstrapScene",OnLoaded);
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {

        }
    }
}