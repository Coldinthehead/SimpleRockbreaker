using System;
using System.Collections.Generic;
using UnityEngine;

public struct BlockState
{
    public int Total;
    public int LeftAlive;

    public BlockState(int total, int leftAlive)
    {
        Total = total;
        LeftAlive = leftAlive;
    }
}

public class BlockHolder : MonoBehaviour
{
    public event Action<BlockState> OnBlockDestroyed;
    private List<Block> _allBlocks;

    private int _aliveCount;

    private void Start()
    {
        _allBlocks = new();
        _allBlocks.AddRange(GetComponentsInChildren<Block>());
        _aliveCount = _allBlocks.Count;
        foreach(var block in _allBlocks)
        {
            block.OnCollision += OnBlockCollision;
        }
    }

    public void Reset()
    {
        foreach(var block in _allBlocks)
        {
            block.Enable();
        }
        _aliveCount = _allBlocks.Count;
    }

    private void OnDisable()
    {
        foreach(var block in _allBlocks)    
        {
            block.OnCollision -= OnBlockCollision;
        }
    }

    private void OnBlockCollision(Block obj)
    {
        _aliveCount--;
        OnBlockDestroyed?.Invoke(new BlockState(_allBlocks.Count,_aliveCount));
    }
}
