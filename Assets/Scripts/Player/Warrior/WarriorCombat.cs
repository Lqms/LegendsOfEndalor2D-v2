using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorCombat : MonoBehaviour
{
    [Header("Attack projectile")]
    [SerializeField] private Projectile _attackProjectile;
    [SerializeField] private float _attackProjectileTime = 0.2f;
    [SerializeField] private float _attackProjectileSpeed = 1;
    [SerializeField] private float _attackProjectileDamage = 25;

    [Header("Strike projectile")]
    [SerializeField] private Projectile _strikeProjectile;
    [SerializeField] private float _strikeProjectileTime = 2;
    [SerializeField] private float _strikeProjectileSpeed = 5;
    [SerializeField] private float _strikeProjectileDamage = 15;

    [Header("Arms")]
    [SerializeField] private Transform _leftArm;
    [SerializeField] private Transform _rightArm;

    [SerializeField] private float _defenseRate = 100;
    [SerializeField] private float _currentDefenseRate = 0;

    private Projectile _activeProjectile;

    public bool IsBlocking { get; private set; }

    public void Attack(bool isSpriteXFlipped)
    {    

        if (isSpriteXFlipped)
        {
            _activeProjectile = Instantiate(_attackProjectile, _leftArm.position, Quaternion.identity);
            _activeProjectile.SetDirection(Vector2.left, _attackProjectileSpeed);
        }
        else
        {
            _activeProjectile = Instantiate(_attackProjectile, _rightArm.position, Quaternion.identity);
            _activeProjectile.SetDirection(Vector2.right, _attackProjectileSpeed);
        }
        
        _activeProjectile.Initialize(_attackProjectileTime, _attackProjectileDamage, false);
    }

    public void Strike(bool isSpriteXFlipped)
    {
        if (isSpriteXFlipped)
        {
            _activeProjectile = Instantiate(_strikeProjectile, _leftArm.position, Quaternion.identity);
            _activeProjectile.SetDirection(Vector2.left, _strikeProjectileSpeed);
        }
        else
        {
            _activeProjectile = Instantiate(_strikeProjectile, _rightArm.position, Quaternion.identity);
            _activeProjectile.SetDirection(Vector2.right, _strikeProjectileSpeed);
        }

        _activeProjectile.Initialize(_strikeProjectileTime, _strikeProjectileDamage, true);
    }

    public void Block(bool isBlocking)
    {
        IsBlocking = isBlocking;

        if (isBlocking)
            _currentDefenseRate = _defenseRate;
        else
            _currentDefenseRate = 0;
    }
}
