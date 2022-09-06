using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract void Attack();

    public abstract void Block(bool isBlocking);

    public abstract void Dash();

    public abstract void FlipSpriteX(bool isFlipped);

    public abstract void Jump();

    public abstract void Move(Vector2 direction);

    public abstract void Strike();

    public abstract void CastUltimate();

    public abstract void StopMove();

    public abstract void Unpause();

    public abstract void Pause();
}
