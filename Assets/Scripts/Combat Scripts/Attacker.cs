using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;

    public float Damage => _damage;

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
