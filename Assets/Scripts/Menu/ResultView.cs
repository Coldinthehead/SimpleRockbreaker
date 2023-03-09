using UnityEngine;
using TMPro;
using System.Collections;
using Scripts.GameState.Services;

namespace Scripts.Menu
{
    public class ResultView : HideableElement
    {
        [SerializeField] private int _tickAmount;
        [SerializeField] private TextMeshProUGUI _lifesText;
        [SerializeField] private TextMeshProUGUI _levelScoreText;
        [SerializeField] private TextMeshProUGUI _totalScore;

        private IPlayerService _playerService;

        public void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public override void Show()
        {
            base.Show();
            ShowLifes(_playerService.PlayerData.Lifes);
            ShowFinishedScore(_playerService.PlayerData.LevelScore, _playerService.PlayerData.TotalScore);
        }

        private void ShowLifes(int amount)
        {
            _lifesText.text = $"Lifes : {amount}";
        }

        private void ShowFinishedScore(int level, int totalCurrent)
        {
            StartCoroutine(LevelAdditionRoutine(level, totalCurrent));
        }

        private IEnumerator LevelAdditionRoutine(int level, int current)
        {
            while(level >=0)
            {
                if(level <= _tickAmount)
                {
                    current += level;
                    level = 0;
                    _levelScoreText.text = $"Level : {level}";
                    _totalScore.text = $"Total : {current}";
                    yield break;
                }

                var step = level /_tickAmount;
                level -= step;
                current += step;

                _levelScoreText.text = $"Level : {level}";
                _totalScore.text = $"Total : {current}";
                yield return null;
            }
        }
    }
}