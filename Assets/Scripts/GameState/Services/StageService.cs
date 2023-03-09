using Scripts.Data;
using System;
using UnityEngine;

namespace Scripts.GameState.Services
{
    public class StageService : IStageService
    {
        public event Action OnStageCompleted;
        public event Action OnLevelCompleted;
        public event Action<LevelArgs> OnLevelStarted;

        public StageTemplate CurrentStage { get; set; }

        public StageDetails CurrentLevel => CurrentStage.Levels[_currentLevelIndex];

        private int _currentLevelIndex;

        public StageService(StageTemplate staget)
        {
            CurrentStage = staget;
            _currentLevelIndex = 0;
        }

        public void StartLevel()
        {
            OnLevelStarted?.Invoke(new LevelArgs(GetCurrentDetails().Background));
        }

        public void CompleteLevel()
        {
            _currentLevelIndex++;
            if (_currentLevelIndex >= CurrentStage.Levels.Count)
            {
                StageCompleted();
            }
            else
            {
                OnLevelCompleted?.Invoke();
            }
        }

        public void StageCompleted()
        {
            _currentLevelIndex = 0;
            Debug.Log("Stage completed ");
            OnStageCompleted?.Invoke();
        }

        public void ResetStage()
        {
            _currentLevelIndex = 0;
            StartLevel();
        }

        public StageDetails GetCurrentDetails()
        {
            return CurrentStage.Levels[_currentLevelIndex];
        }

     
    }
}