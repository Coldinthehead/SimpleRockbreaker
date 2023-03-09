using Scripts.Data;
using System;
using UnityEngine;

namespace Scripts.GameState.Services
{
    public struct LevelArgs
    {
        public readonly Sprite Sprite;

        public LevelArgs(Sprite sprite)
        {
            Sprite = sprite;
        }
    }

    public interface IStageService : IService
    {
        public event Action OnStageCompleted;
        public event Action OnLevelCompleted;
        public event Action<LevelArgs> OnLevelStarted;
        
        public StageTemplate CurrentStage { get; set; }
        public StageDetails CurrentLevel { get; }

        public void CompleteLevel();
        public void ResetStage();
        public void StartLevel();

        public StageDetails GetCurrentDetails();

    }
}