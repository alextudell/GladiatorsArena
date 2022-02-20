using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //[SerializeField] 
    //private int _health = 100;
    //public int Health => _health;

    //[SerializeField] 
    //private int _attackDamage = 10;
    //public int AttackDamage => _attackDamage;

    public abstract void ApplyDamage(int damage);


    //public void ApplyDamage(int damage)
    //{
    //    _health -= damage;
    //}
}
