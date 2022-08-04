using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WarriorMover : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _dashPower = 10f;

    [Header("Jump")]
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _radiusLegs;
    [SerializeField] private bool _canJump;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private Warrior _warrior;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _warrior = GetComponent<Warrior>();
    }

    private void FixedUpdate()
    {
        _canJump = Physics2D.OverlapCircle(_warrior.Legs.position, _radiusLegs, _groundMask);
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
        _direction = direction;
    }

    public void StopMove()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        if (_canJump)
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    public void Dash()
    {
        _rigidbody.AddForce(_direction * _dashPower, ForceMode2D.Force);
    }
}
