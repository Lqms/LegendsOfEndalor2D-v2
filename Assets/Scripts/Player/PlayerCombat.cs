using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerSound))]
public class PlayerCombat : MonoBehaviour
{
    private Animator _animator;
    private PlayerSound _playerSound;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerSound = GetComponent<PlayerSound>(); 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
            _playerSound.PlayAttackClip();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _animator.SetTrigger("Strike");
            _playerSound.PlayStrikeClip();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _animator.SetBool("isBlocking", true);
            _playerSound.PlayBlockClip();
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _animator.SetBool("isBlocking", false);
        }
    }
}
