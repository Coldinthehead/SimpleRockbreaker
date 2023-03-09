using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _maxMagniture;

    [SerializeField] private float _tweekBounds;
    [SerializeField] private float _tweekAmount;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var _rb = collision.rigidbody;
        if (_rb.velocity.y > -_tweekBounds && _rb.velocity.y < _tweekBounds)
        {
            var speed = _rb.velocity.magnitude;
            var newVelocity = new Vector2(_rb.velocity.x, _rb.velocity.y + _tweekAmount * Mathf.Sign(_rb.velocity.y)).normalized;

            speed = Mathf.Min(speed, _maxMagniture);
            _rb.velocity = newVelocity * speed;
        }
        else if (_rb.velocity.x > -_tweekBounds && _rb.velocity.x < _tweekBounds)
        {
            var speed = _rb.velocity.magnitude;
            var newVelocity = new Vector2(_rb.velocity.x + _tweekAmount *Mathf.Sign(_rb.velocity.x) ,  _rb.velocity.y).normalized;
            speed = Mathf.Min(speed, _maxMagniture);
            _rb.velocity = newVelocity * speed;
        }
    }
}
