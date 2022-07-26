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

    private bool _isPaused = false;

    private void Start()
    {
        _spriteRendeter = GetComponent<WarriorSpriteRenderer>();
        _mover = GetComponent<WarriorMover>();
        _animator = GetComponent<WarriorAnimator>();
        _combat = GetComponent<WarriorCombat>();
    }

    public override void Attack()
    {
        if (_isPaused)
            return;

        _combat.Attack(_spriteRendeter.FlipX);
        _animator.PlayAttack();
    }

    public override void Block(bool isBlocking)
    {
        if (_isPaused && isBlocking)
            return;

        _combat.Block(isBlocking);
        _animator.PlayBlock(isBlocking);
    }

    public override void Dash()
    {
        if (_isPaused)
            return;

        _animator.PlayDash();
        _mover.Dash();
    }

    public override void FlipSpriteX(bool isFlipped)
    {
        _spriteRendeter.FlipSPriteX(isFlipped);
    }

    public override void Jump()
    {
        if (_isPaused)
            return;

        _mover.Jump();
        _animator.PlayJump();
    }

    public override void Move(Vector2 direction)
    {
        /*
        if (_isPaused && _mover.CanJump == false)
            return;
        */

        if (_combat.IsBlocking)
            return;

        _mover.Move(direction);
        _animator.PlayRun(true);
    }

    public override void Strike()
    {
        if (_isPaused)
            return;

        _combat.Strike(_spriteRendeter.FlipX);
        _animator.PlayStrike();
    }

    public override void Ultimate()
    {
        if (_isPaused)
            return;

        Debug.Log("Ultimate");
    }

    public override void StopMove()
    {
        _mover.StopMove();
        _animator.PlayRun(false);
    }

    public override void Unpause()
    {
        _isPaused = false;
    }

    public override void Pause()
    {
        _isPaused = true;
    }
}
