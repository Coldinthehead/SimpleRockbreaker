using Scripts.GameState.Services;

namespace Scripts.GameState.States
{
    public class LoadPlayerProgressState : BaseGameState, IGameState
    {
        private readonly IPlayerService _playerData;
        public LoadPlayerProgressState(GameStateMachine stateMachine, IPlayerService playerData) : base(stateMachine)
        {
            _playerData = playerData;
        }

        public void Enter()
        {
            RegisterPlayerData();
            _stateMachine.Enter<BuildLevelState>();
        }

        private void RegisterPlayerData()
        {
            _playerData.PlayerData = CreatePlayerData();
        }


        private PlayerData CreatePlayerData()
        {
            var playerData = new PlayerData();
            playerData.LevelScore = 0;
            playerData.Lifes = 3;
            playerData.TotalScore = 0;
            return playerData;
        }

        public void Exit()
        {
           
        }
    }
}