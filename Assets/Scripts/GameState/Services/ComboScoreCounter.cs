using System;
using UnityEngine;

namespace Scripts.GameState.Services
{
    public class ComboScoreCounter : IScoreCounter
    {
        public event Action<float,int> OnTimerStarted;

        private const int DefaultScoreValue = 100;
        private const int BaseScoreMultiplier = 1;
        private const float BaseComboDuration = 2f;
        private readonly PlayerData _playerData;
        private int _multiplier;
        private float _lastBallDieTime;
        private float _duration;
        public ComboScoreCounter(PlayerData playerData)
        {
            _playerData = playerData;
            _multiplier = BaseScoreMultiplier;
            _duration = BaseComboDuration;
        }

        public void OnBallDestroyed()
        {
            _playerData.LevelScore += DefaultScoreValue * _multiplier;

            if (Time.time > _lastBallDieTime + _duration)
            {
                _multiplier = BaseScoreMultiplier;
            }
            else
            {
                _multiplier++;
            }

            _lastBallDieTime = Time.time;
            OnTimerStarted?.Invoke(_duration, _multiplier);
        }
    }
}