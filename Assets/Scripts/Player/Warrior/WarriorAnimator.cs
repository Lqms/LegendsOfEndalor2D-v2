using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WarriorAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string IsRunning = "IsRunning";
    private const string Jump = "Jump";
    private const string Dash = "Dash";
    private const string Attack = "Attack";
    private const string Strike = "Strike";
    private const string IsBlocking = "IsBlocking";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRun(bool isPlaying)
    {
        _animator.SetBool(IsRunning, isPlaying);
    }

    public void PlayJump()
    {
        _animator.SetTrigger(Jump);
    }

    public void PlayDash()
    {
        _animator.SetTrigger(Dash);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void PlayStrike()
    {
        _animator.SetTrigger(Strike);
    }

    public void PlayBlock(bool isBlocking)
    {
        _animator.SetBool(IsBlocking, isBlocking);
    }
}
