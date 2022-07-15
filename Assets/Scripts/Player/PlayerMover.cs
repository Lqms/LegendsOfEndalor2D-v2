using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;

    [Header("Jump")]
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _radiusLegs;
    [SerializeField] private Transform _legs;
    [SerializeField] private bool _canJump;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        Move(inputHorizontal);
        _animator.SetBool("isRunning", inputHorizontal != 0);

        if (inputHorizontal != 0)
            FlipSpriteX(inputHorizontal < 0);


        if (_canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            _animator.SetTrigger("Jump");
        }
    }

    private void FixedUpdate()
    {
        _canJump = Physics2D.OverlapCircle(_legs.position, _radiusLegs, _groundMask);
    }

    private void Move(float direction)
    {
        _rigidBody.velocity = new Vector2(_speed * direction, _rigidBody.velocity.y);
    }

    private void FlipSpriteX(bool isFlipped)
    {
        _spriteRenderer.flipX = isFlipped;
    }

    private void Jump()
    {
        _rigidBody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }
}
