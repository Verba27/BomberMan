using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 direction = Vector2.left;
    [SerializeField] private LayerMask raycastMask;
    private bool isPossibleToMove;
    private void Start()
    {
        //MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (Raycast(direction))
        {
            direction.x = direction.x * -1; 
        }
        
        isPossibleToMove = true;
        var pos = (Vector2)transform.position + direction;
        transform.DOMove(pos, 0.5f).OnComplete(() =>
        {
            isPossibleToMove = false;
        });
        transform.DOMove( direction, 10f);
    }
    
    private bool Raycast(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir, 1f, raycastMask);
        return hit.collider != null;
    }
    
}
