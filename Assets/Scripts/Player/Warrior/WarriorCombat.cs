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

    public void Attack(bool isSpriteXFlipped)
    {    
        if (isSpriteXFlipped)
        {
            Projectile projectile = Instantiate(_attackProjectile, _leftArm.position, Quaternion.identity);
            projectile.Initialize(Vector2.left, _attackProjectileSpeed, _attackProjectileTime, _attackProjectileDamage, false);
        }
        else
        {
            Projectile projectile = Instantiate(_attackProjectile, _rightArm.position, Quaternion.identity);
            projectile.Initialize(Vector2.right, _attackProjectileSpeed, _attackProjectileTime, _attackProjectileDamage, false);
        }
    }

    public void Strike(bool isSpriteXFlipped)
    {
        if (isSpriteXFlipped)
        {
            Projectile projectile = Instantiate(_strikeProjectile, _leftArm.position, Quaternion.identity);
            projectile.Initialize(Vector2.left, _strikeProjectileSpeed, _strikeProjectileTime, _strikeProjectileDamage, true);
        }
        else
        {
            Projectile projectile = Instantiate(_strikeProjectile, _rightArm.position, Quaternion.identity);
            projectile.Initialize(Vector2.right, _strikeProjectileSpeed, _strikeProjectileTime, _strikeProjectileDamage, true);
        }
    }
}
