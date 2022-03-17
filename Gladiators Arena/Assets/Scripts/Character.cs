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
    private int _counterattackDamage = 15;
    public int CounterattackDamage => _counterattackDamage;

    [SerializeField]
    private int _forceAttackDamage = 20;
    public int ForceAttackDamage => _forceAttackDamage;

    [SerializeField] protected CharacterView characterView;

    public virtual void ApplyDamage(DamageInfo damage)
    {
            _health -= damage.DamageValue;

            if (_health < 0)
            {
                _health = 0;
            }
    }

    public virtual void AttackClip(bool forceAttack, BodyPart defenderBodyPart)
    {
        characterView.HitInBodyPart(forceAttack, defenderBodyPart);
    }

    public virtual void TakingDamageClip(bool forceDefence, BodyPart defenderBodyPart, BodyPart attackerBodyPart)
    {
        characterView.GotInBodyPart(forceDefence, defenderBodyPart, attackerBodyPart);
    }


    public virtual void DefendedClip(bool forceDefence, BodyPart defendedBodyPart)
    {
        characterView.DefendedBodyPart(forceDefence, defendedBodyPart);
    }

    public virtual void VictoryClip()
    {
        characterView.VictoryClip();
    }

    public virtual void DeadClip()
    {
        characterView.DeadClip();
    }
}
