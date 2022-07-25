using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WarriorMover))]
[RequireComponent(typeof(WarriorSpriteRenderer))]
[RequireComponent(typeof(WarriorAnimator))]
public class Warrior : Character
{
    private WarriorMover _mover;
    private WarriorSpriteRenderer _spriteRendeter;
    private WarriorAnimator _animator;

    private void Start()
    {
        _spriteRendeter = GetComponent<WarriorSpriteRenderer>();
        _mover = GetComponent<WarriorMover>();
        _animator = GetComponent<WarriorAnimator>();
    }

    public override void Attack()
    {
        Debug.Log("Attack");
    }

    public override void Block(bool isBlocking)
    {
        Debug.Log("Block");
    }

    public override void Dash()
    {
        Debug.Log("Dash");
    }

    public override void FlipSpriteX(bool isFlipped)
    {
        _spriteRendeter.FlipSPriteX(isFlipped);
    }

    public override void Jump()
    {
        Debug.Log("Jump");
    }

    public override void Move(Vector2 direction)
    {
        _mover.Move(direction);
        _animator.PlayRun();
    }

    public override void PowerAttack()
    {
        Debug.Log("PowerAttack");
    }

    public override void Ultimate()
    {
        Debug.Log("Ultimate");
    }

    public override void StopMove()
    {
        _mover.StopMove();
        _animator.PlayIdle();
    }
}
