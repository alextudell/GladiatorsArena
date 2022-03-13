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
    private int _forceAttackDamage = 20;
    public int ForceAttackDamage => _forceAttackDamage;

    [SerializeField] protected CharacterView characterView;

    public virtual void ApplyDamage(bool forceAttack, bool hasDamage, DamageInfo damage)
    {
        if (hasDamage)
        {
            characterView.HitInBodyPart(forceAttack, damage.BodyPart);
            _health -= damage.DamageValue;

            if (_health < 0)
            {
                _health = 0;
            }
        }
        else
        {
            characterView.HitInBodyPart(forceAttack, damage.BodyPart);
        }
    }

    public virtual void TakingDamageClip(bool forceDefence, bool hasDefence, BodyPart defenderBodyPart, BodyPart attackerBodyPart)
    {
        characterView.GotInBodyPart(forceDefence, hasDefence, defenderBodyPart, attackerBodyPart);
    }


    public virtual void DefendedClip(bool forceDefence, BodyPart defendedBodyPart)
    {
        characterView.DefendedBodyPart(forceDefence, defendedBodyPart);
    }

}
