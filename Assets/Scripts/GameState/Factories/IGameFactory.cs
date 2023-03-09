using Scripts.GameState.Services;
using UnityEngine;

namespace Scripts.GameState.Factories
{
    public interface IGameFactory : IService
    {
        public LevelState LevelState { get; }
        public Paddle CreatePaddle(Transform initialPoint);
        public Ball CreateBall();

        public BackgroundChanger CreateBackground(GameObject gameObject);

        public LevelState CreateLevelState(LoseTrigger loseTrigger, GameObject initialiPoint);
        public BlockHolder CreateBlockForCurrentLevel();

        public void InitPlayer();
        void Clearup();
    }
}