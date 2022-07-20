using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class RunState : State
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private PlayerInput _playerInput;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
    }

    protected override void Setup()
    {
        Debug.Log("вкл. анимацию Run");
    }

    private void Move()
    {
        _rigidBody.velocity = new Vector2(_speed * _playerInput.Direction.x, _rigidBody.velocity.y);

        if (_playerInput.Direction.x != 0)
            FlipX(_playerInput.Direction.x < 0);
    }

    private void FlipX(bool isFlipped)
    {
        _spriteRenderer.flipX = isFlipped;
    }
}
