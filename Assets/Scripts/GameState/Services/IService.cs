using System;

namespace Scripts.GameState.Services
{
    public interface IScoreCounter
    {
        public event Action<float, int> OnTimerStarted;
        public void OnBallDestroyed();
    }
    public interface IService
    { 
    }
}