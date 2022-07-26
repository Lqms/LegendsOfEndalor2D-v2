using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WarriorMover))]
[RequireComponent(typeof(WarriorSpriteRenderer))]
[RequireComponent(typeof(WarriorAnimator))]
[RequireComponent(typeof(WarriorCombat))]
public class Warrior : Character
{
    private WarriorMover _mover;
    private WarriorSpriteRenderer _spriteRendeter;
    private WarriorAnimator _animator;
    private WarriorCombat _combat;

    private void Start()
    {
        _spriteRendeter = GetComponent<WarriorSpriteRenderer>();
        _mover = GetComponent<WarriorMover>();
        _animator = GetComponent<WarriorAnimator>();
        _combat = GetComponent<WarriorCombat>();
    }

    public override void Attack()
    {
        _combat.Attack(_spriteRendeter.FlipX);
        _animator.PlayAttack();
    }

    public override void Block(bool isBlocking)
    {
        Debug.Log("Block");
    }

    public override void Dash()
    {
        _animator.PlayDash();
        _mover.Dash();
    }

    public override void FlipSpriteX(bool isFlipped)
    {
        _spriteRendeter.FlipSPriteX(isFlipped);
    }

    public override void Jump()
    {
        _mover.Jump();
        _animator.PlayJump();
    }

    public override void Move(Vector2 direction)
    {
        _mover.Move(direction);
        _animator.PlayRun(true);
    }

    public override void Strike()
    {
        _combat.Strike(_spriteRendeter.FlipX);
        _animator.PlayStrike();
    }

    public override void Ultimate()
    {
        Debug.Log("Ultimate");
    }

    public override void StopMove()
    {
        _mover.StopMove();
        _animator.PlayRun(false);
    }
}
