using System;
using UnityEngine;

public class LevelState 
{
    public event Action<BlockState> OnBlockDestroyed;
    public event Action OnBallMissed;

    private readonly LoseTrigger _loseTrigger;
    private readonly Paddle _paddle;
    private readonly Ball _ball;
    private readonly Vector3 _initialiPosition;
    private readonly BallStarter _ballStarter;
    private BlockHolder _blocks;

    public LevelState(LoseTrigger loseTrigger, Paddle paddle, Ball ball, Vector3 initialiPosition)
    {
        _loseTrigger = loseTrigger;
        _loseTrigger.OnTriggerEnter += BallMissed;
        _paddle = paddle;
        _ball = ball;
        _initialiPosition = initialiPosition;
        _ballStarter = paddle.GetComponentInChildren<BallStarter>();
    }

    public void StartLevel(BlockHolder blocks)
    {
        _blocks = blocks;

        _blocks.OnBlockDestroyed += BlockDestroyed;
        ResetPaddle();
    }

    public void SlowTime()
    {
        Time.timeScale = 0.1f;
        _loseTrigger.gameObject.SetActive(false);
    }

    public void NormalizeTime()
    {
        Time.timeScale = 1;
        _loseTrigger.gameObject.SetActive(true);
    }

    public void ClearBlocks()
    {
        if (_blocks != null)
        {
            _blocks.OnBlockDestroyed -= BlockDestroyed;
            GameObject.Destroy(_blocks.gameObject);
        }
     
    }


    private void BlockDestroyed(BlockState args)
    {
        OnBlockDestroyed?.Invoke(args);
    }

    private void BallMissed()
    {
        OnBallMissed?.Invoke();
        ResetPaddle();
    }

    private void ResetPaddle()
    {
        _paddle.transform.position = _initialiPosition;
        _ball.Stop();
        _ballStarter.Enable(_ball);
    }
}
