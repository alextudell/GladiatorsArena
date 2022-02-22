using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanPlayerController : PlayerController
{
    private BodyPart _attack;
    public BodyPart Attack => _attack;
    
    private BodyPart _defence;
    public BodyPart Defence => _defence;

    public Action OnAttackBodyPartChanged;
    public Action OnDefenceBodyPartChanged;

    private bool _forceAttack;
    public bool ForceAttack => _forceAttack;

    private bool _forceDefence;
    public bool ForceDefence => _forceDefence;


    public void SetAttackBodyPart(BodyPart part)
    {
        if(ForceDefence)
        {
            return;
        }
        if (_attack == BodyPart.None)
        {
            _forceAttack = false;
        }
        else if (_attack == part)
        {
            _forceAttack = true;
        }

            _attack = part;
            OnAttackBodyPartChanged?.Invoke();
    }
    
    public void SetDefenceBodyPart(BodyPart part)
    {
        _defence = part;
        OnDefenceBodyPartChanged?.Invoke();
    }
    
    public override TurnInfo GetTurn()
    {
        var turn = new TurnInfo();
        turn.forceAttack = _forceAttack;
        turn.forceDefence = _forceDefence;
        turn.attackBodyPart = _attack;
        turn.defenceBodyPart = _defence;
        return turn;
    }

    public override void Reset()
    {
        _forceAttack = false;
        _attack = BodyPart.None;
        _defence = BodyPart.None;
        OnAttackBodyPartChanged?.Invoke();
        OnDefenceBodyPartChanged?.Invoke();
    }
}
