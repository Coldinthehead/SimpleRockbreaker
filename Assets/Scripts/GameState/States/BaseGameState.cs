namespace Scripts.GameState.States
{
    public abstract class BaseGameState
    {
        protected readonly GameStateMachine _stateMachine;

        public BaseGameState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}