using Scripts.GameState.Services;
using System;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private IStageService _stageService;
    public void Construct(IStageService stageService)
    {
        _stageService = stageService;
        _stageService.OnLevelStarted += OnLevelStarted;
        SetBackground(_stageService.GetCurrentDetails().Background);
    }
    private void OnDestroy()
    {
        if (_stageService != null)
        { 
        _stageService.OnLevelStarted -= OnLevelStarted;
        }
    }

    private void OnLevelStarted(LevelArgs obj)
    {
        SetBackground(obj.Sprite);
    }

    private void SetBackground(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
