using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Attacker))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Attacker _attacker;
    private bool _isDestroyingOnHit;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _attacker = GetComponent<Attacker>();
    }

    public void Initialize(float timeToDestroy, float damage, bool isDestroyingOnHit)
    {
        _isDestroyingOnHit = isDestroyingOnHit;
        _attacker.SetDamage(damage);
        Destroy(gameObject, timeToDestroy);
    }

    public void SetDirection(Vector2 direction, float speed)
    {
        _rigidBody.velocity = direction.normalized * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInput player))
            return;

        if (_isDestroyingOnHit)
            Destroy(gameObject, 0.1f);
    }
}
