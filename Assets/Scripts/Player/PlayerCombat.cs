using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerSound), typeof(PlayerMover))]
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Collider2D _attackCollider;
    [SerializeField] private float _attackRate;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _armsPosition;

    private Animator _animator;
    private PlayerSound _playerSound;
    private PlayerMover _playerMover;
    private Vector2 _attackColliderSize;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerSound = GetComponent<PlayerSound>(); 
        _playerMover = GetComponent<PlayerMover>();
        _attackColliderSize = _attackCollider.transform.localScale;
        _attackCollider.transform.localScale = Vector2.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();

        if (Input.GetMouseButtonDown(1))
            Strike();

        if (Input.GetKeyDown(KeyCode.Q))
            Block(true);

        if (Input.GetKeyUp(KeyCode.Q))
            Block(false);
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        _playerSound.PlayAttackClip();
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        _attackCollider.transform.localScale = _attackColliderSize;
        yield return new WaitForSeconds(_attackRate);
        _attackCollider.transform.localScale = Vector2.zero;
    }

    private void Strike()
    {
        var projectile = Instantiate(_projectile, _armsPosition.position, Quaternion.identity);
        projectile.SetDirection(_playerMover.IsXFlipped? Vector2.left : Vector2.right);
        _animator.SetTrigger("Strike");
        _playerSound.PlayStrikeClip();
    }

    private void Block(bool isBlocking)
    {
        _animator.SetBool("isBlocking", isBlocking);

        if (isBlocking)
            _playerSound.PlayBlockClip();
    }
}
