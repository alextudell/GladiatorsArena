using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murmillon : Character
{
    [SerializeField]
    private int _health = 120;
    public int Health => _health;

    [SerializeField]
    private int _attackDamage = 10;
    public int AttackDamage => _attackDamage;

    public override void ApplyDamage(int damage)
    {
        _health -= damage;
    }

}
