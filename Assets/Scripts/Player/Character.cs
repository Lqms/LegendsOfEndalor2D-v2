using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public virtual void Attack()
    {
        Debug.Log("Attack");
    }

    public virtual void Block(bool isBlocking)
    {
        Debug.Log("Block");
    }

    public virtual void Dash()
    {
        Debug.Log("Dash");
    }

    public virtual void FlipSpriteX(bool isFlipped)
    {
        Debug.Log("FlipX");
    }

    public virtual void Jump()
    {
        Debug.Log("Jump");
    }

    public virtual void Move(Vector2 direction)
    {
        Debug.Log("Move");
    }

    public virtual void PowerAttack()
    {
        Debug.Log("PowerAttack");
    }

    public virtual void Ultimate()
    {
        Debug.Log("Ultimate");
    }

    public virtual void StopMove()
    {
        Debug.Log("Stop");
    }
}
