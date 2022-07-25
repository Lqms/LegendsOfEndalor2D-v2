using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WarriorAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string Idle = "WarriorIdleAnim";
    private const string Run = "WarriorRunAnim";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        _animator.Play(Idle);
    }

    public void PlayRun()
    {
        _animator.Play(Run);
    }

    public void StopPlayBack()
    {
        _animator.StopPlayback();
    }
}
