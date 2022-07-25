using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WarriorMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
    }

    public void StopMove()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
}
