using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action<Block> OnCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision?.Invoke(this);
        Disable();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
