using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WarriorMover))]
[RequireComponent(typeof(WarriorSpriteRenderer))]
[RequireComponent(typeof(WarriorAnimator))]
[RequireComponent(typeof(WarriorCombat))]
public class Warrior : Character
{
    [Header("Body")]
    [SerializeField] private Transform _legs;
    [SerializeField] private Transform _leftArm;
    [SerializeField] private Transform _rightArm;

    private WarriorMover _mover;
    private WarriorSpriteRenderer _spriteRendeter;
    private WarriorAnimator _animator;
    private WarriorCombat _combat;

    private bool _isPaused = false;

    public Transform Legs => _legs;
    public Transform LeftArm => _leftArm;
    public Transform RightArm => _rightArm;

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

        Pause();

        _combat.Attack(_spriteRendeter.FlipX);
        _animator.PlayAttack();
    }

    public override void Block(bool isBlocking)
    {
        if (_isPaused && isBlocking)
            return;

        Pause();

        _combat.Block(isBlocking);
        _animator.PlayBlock(isBlocking);
    }

    public override void Dash()
    {
        if (_isPaused)
            return;

        Pause();

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

        Pause();

        _mover.Jump();
        _animator.PlayJump();
    }

    public override void Move(Vector2 direction)
    {
        if (_combat.IsBlocking)
            return;

        _mover.Move(direction);
        _animator.PlayRun(true);
    }

    public override void Strike()
    {
        if (_isPaused)
            return;

        Pause();

        _combat.Strike(_spriteRendeter.FlipX);
        _animator.PlayStrike();
    }

    public override void CastUltimate()
    {
        if (_isPaused)
            return;

        Pause();

        _combat.CastUltimate();
        _animator.PlayUltimate();
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
