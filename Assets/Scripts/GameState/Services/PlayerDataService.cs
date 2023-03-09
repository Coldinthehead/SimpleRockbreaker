using System;

namespace Scripts.GameState.Services
{
    public class PlayerDataService : IPlayerService
    {
        public event Action OnLifesEnded;
        public PlayerData PlayerData { get; set; }
        public IScoreCounter ScoreCounter { get; set; }



        public void ResetStats()
        {
            PlayerData.LevelScore = 0;
            PlayerData.Lifes = 3;
            PlayerData.TotalScore = 0;

        }
        public void CompleteLevel()
        {
            PlayerData.TotalScore += PlayerData.LevelScore;
            PlayerData.LevelScore = 0;
        }

        public void RemoveLife()
        {
            PlayerData.Lifes--;
            if (PlayerData.Lifes<=0)
            {
                OnLifesEnded?.Invoke();
            }
        }
    }
}