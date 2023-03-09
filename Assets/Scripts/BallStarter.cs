using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStarter : MonoBehaviour
{
    [SerializeField] private Transform _startPostion;
    [SerializeField] private float _startForce;
    private Ball _ball;

    private void Update()
    {
        SyncroniseYPosition();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RunBall();
        }
    }

    private void SyncroniseYPosition()
    {
        _ball.transform.position = new Vector3(transform.position.x, _startPostion.position.y);

    }

    private void RunBall()
    {
        var horizontaldirection = Random.Range(0.5f, 1f) * Mathf.Sign(Random.Range(-1, 1));
        var force = (Vector2.up + Vector2.right * horizontaldirection) * _startForce;
        _ball.Run(force);
        Disable();
    }

    public void Disable()
    {
        enabled = false;
    }

    public void Enable(Ball ball)
    {
        _ball = ball;
        _ball.Stop();
        _ball.transform.position = _startPostion.position;
        enabled = true;
    }
}
