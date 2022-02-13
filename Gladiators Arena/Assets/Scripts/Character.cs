using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] 
    private int _health = 100;
    public int Health => _health;

    [SerializeField] 
    private int _attackDamage = 10;
    public int AttackDamage => _attackDamage;

    public void ApplyDamage(int damage)
    {
        _health -= damage;
    }
}
