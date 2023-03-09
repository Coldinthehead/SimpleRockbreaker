
using System;

public class PlayerData
{
    public event Action<int> OnLifesChanged;
    public event Action<int> OnScoreChanged;

    public int Lifes
    {
        get => _lifes;
        set
        {
            _lifes = value;
            OnLifesChanged?.Invoke(_lifes);
        }
    }

    public int TotalScore;

    public int LevelScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            OnScoreChanged?.Invoke(_currentScore);
        }
    }

    private int _lifes;
    private int _currentScore;
}
