using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private int _health = 120;
    public int Health => _health;

    [SerializeField]
    private int _attackDamage = 10;
    public int AttackDamage => _attackDamage;

    [SerializeField]
    private int _forceAttackDamage = 10;
    public int ForceAttackDamage => _forceAttackDamage;

    [SerializeField] protected CharacterView characterView;

    public virtual void ApplyDamage(DamageInfo damage)
    {
        characterView.HitInBodyPart(damage.BodyPart);
        _health -= damage.DamageValue;
        //characterView.GotInBodyPart(damage.BodyPart);

        if (_health < 0)
        {
            _health = 0;
        }
    }

}
