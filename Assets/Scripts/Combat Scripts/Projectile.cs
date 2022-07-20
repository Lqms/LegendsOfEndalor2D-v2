using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _timeToDestroy);
    }

    public void SetDirection(Vector2 direction)
    {
        _rigidBody.velocity = direction.normalized * _speed;
    }
}
