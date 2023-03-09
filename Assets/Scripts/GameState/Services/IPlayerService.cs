using System;

namespace Scripts.GameState.Services
{

    public interface IPlayerService : IService
    {
        public event Action OnLifesEnded;

        public PlayerData PlayerData{get;set; }

        public IScoreCounter ScoreCounter { get; set; }


        public void ResetStats();
        public void CompleteLevel();

        public void RemoveLife();
    }
}