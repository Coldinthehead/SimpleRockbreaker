using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    public void Run(Vector2 force)
    {
        _rb.AddForce(force, ForceMode2D.Impulse);

    }

    public void Stop()
    {
        _rb.velocity = Vector2.zero;
    }


   
}
