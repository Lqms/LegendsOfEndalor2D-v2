using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerSound))]
public class PlayerMover : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _dashPower;
    [SerializeField] private Collider2D _attackCollider;
    [SerializeField] private Transform _armsPosition;

    [Header("Jump")]
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _radiusLegs;
    [SerializeField] private Transform _legs;
    [SerializeField] private bool _canJump;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private PlayerSound _playerSound;
    private float _attackColliderXOffset;
    private float _armsPositionX;

    public bool IsXFlipped { get; private set; }


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerSound = GetComponent<PlayerSound>();
        _attackColliderXOffset = _attackCollider.offset.x;
        _armsPositionX = _armsPosition.position.x;
    }

    private void Update()
    {
        Move();

        if (_canJump && Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            Dash();
    }

    private void FixedUpdate()
    {
        _canJump = Physics2D.OverlapCircle(_legs.position, _radiusLegs, _groundMask);
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        _animator.SetBool("isRunning", inputHorizontal != 0);
        _rigidBody.velocity = new Vector2(_speed * inputHorizontal, _rigidBody.velocity.y);

        if (inputHorizontal != 0)
            FlipX(inputHorizontal < 0);
    }

    private void FlipX(bool isFlipped)
    {
        _spriteRenderer.flipX = isFlipped;
        IsXFlipped = isFlipped;

        if (isFlipped)
        {
            _attackCollider.offset = new Vector2(-_attackColliderXOffset, _attackCollider.offset.y);
            _armsPosition.position = new Vector3(-_armsPositionX, _armsPosition.position.y, 0);
        }

        else
        {
            _attackCollider.offset = new Vector2(_attackColliderXOffset, _attackCollider.offset.y);
            _armsPosition.position = new Vector3(_armsPositionX, _armsPosition.position.y, 0);
        }
    }

    private void Jump()
    {
        _playerSound.PlayJumpClip();
        _animator.SetTrigger("Jump");
        _rigidBody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    private void Dash()
    {
        _playerSound.PlayDashClip();
        _animator.SetTrigger("Dash");
        _rigidBody.AddForce(_dashPower * _rigidBody.velocity, ForceMode2D.Force);
    }
}
