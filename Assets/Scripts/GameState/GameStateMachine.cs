using Scripts.Data;
using Scripts.GameState.Factories;
using Scripts.GameState.Services;
using Scripts.GameState.States;
using System;
using System.Collections.Generic;

namespace Scripts.GameState
{
    public class GameStateMachine
    {
        private Dictionary<Type, IGameState> _states;
        private IGameState _currentState;

        public GameStateMachine(ServiceLocator services,SceneLoader sceneLoader, StageTemplate starges)
        {
            _states = new Dictionary<Type, IGameState>();

            _states[typeof(BootstrapState)] = new BootstrapState(this
                , services
                , sceneLoader
                , starges);

            _states[typeof(MainMenuState)] = new MainMenuState(this
                , services.Single<IUIFactory>()
                , sceneLoader);
            
            _states[typeof(BuildLevelState)] = new BuildLevelState(this
                , sceneLoader
                , services.Single<IGameFactory>()
                , services.Single<IUIFactory>());

            _states[typeof(GameplayState)] = new GameplayState(this
                , services.Single<IGameFactory>()
                , services.Single<IPlayerService>()
                , services.Single<IUIFactory>()
                , services.Single<IStageService>());

            _states[typeof(LoseState)] = new LoseState(this
                , services.Single<IUIFactory>()
                , services.Single<IPlayerService>()
                , services.Single<IStageService>());

            _states[typeof(LevelCompletedState)] = new LevelCompletedState(this
                , services.Single<IUIFactory>()
                , services.Single<IPlayerService>());

            _states[typeof(StageCompletedState)] = new StageCompletedState(this
                , services.Single<IUIFactory>());

            _states[typeof(LoadPlayerProgressState)] = new LoadPlayerProgressState(this
                , services.Single<IPlayerService>());
        }

        public void Enter<T>() where T : IGameState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(T)];
            _currentState.Enter();
        }
    }
}