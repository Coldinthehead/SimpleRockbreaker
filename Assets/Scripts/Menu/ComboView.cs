using Scripts.GameState.Services;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Scripts.Menu
{
    public class ComboView : HideableElement
    {
        [SerializeField] private TextMeshProUGUI _comboTime;
        [SerializeField] private TextMeshProUGUI _comboMultiplier;

        private Coroutine _currentTimer;
        private IPlayerService _playerService;
        public void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
            _playerService.ScoreCounter.OnTimerStarted += OnComboStarted;
        }

        private void OnDestroy()
        {
            Debug.Log("Combo view destroy");
            _playerService.ScoreCounter.OnTimerStarted -= OnComboStarted;

        }

        private void OnComboStarted(float duration, int multiplier)
        {
            ChangeMultplier(multiplier);
           ShowTimer(duration);
        }

        private void ChangeMultplier(int multiplier)
        {
            _comboMultiplier.text = $"{multiplier} X";
        }

        private void ShowTimer(float duration)
        {
            Show();
            if(_currentTimer != null)
            {
                StopCoroutine(_currentTimer);
            }

            _currentTimer = StartCoroutine(ShowTimerRoutine(duration));
        }

        private IEnumerator ShowTimerRoutine(float amount)
        {
            for(float i = amount; i> 0;i-= Time.deltaTime)
            {
               _comboTime.text = i.ToString("0.00");
                yield return null;
            }
            Hide();
        }
    }
}