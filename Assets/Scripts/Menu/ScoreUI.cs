using Scripts.GameState.Services;
using TMPro;
using UnityEngine;

namespace Scripts.Menu
{
    public class ScoreUI : HideableElement
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _lifesText;

        private IPlayerService _playerService;

        public void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
            _playerService.PlayerData.OnLifesChanged += OnLifesChanged;
            _playerService.PlayerData.OnScoreChanged += OnScoreChanged;

            SetLifes(_playerService.PlayerData.Lifes);
            SetScore(_playerService.PlayerData.LevelScore);
        }

        private void OnScoreChanged(int scoreValue)
        {
            SetScore(scoreValue);
        }

        private void OnLifesChanged(int lifesValue)
        {
            SetLifes(lifesValue);
        }

        private void OnDestroy()
        {
            _playerService.PlayerData.OnLifesChanged -= OnLifesChanged;
            _playerService.PlayerData.OnScoreChanged -= OnScoreChanged;
        }

        private void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }

        private void SetLifes(int lifes)
        {
            _lifesText.text = lifes.ToString();
        }
    }
}