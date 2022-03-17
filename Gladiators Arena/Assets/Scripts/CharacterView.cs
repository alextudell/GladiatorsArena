using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    //[SerializeField] SpriteRenderer spriteRend;

    public void GotInBodyPart (bool forceDefence, BodyPart defenderBodyPart, BodyPart attackerBodyPart)
    {
        //spriteRend.sortingOrder = 100;

        if (defenderBodyPart == BodyPart.None && attackerBodyPart == BodyPart.Head)
        {
            _animator.SetTrigger("GotInHead");
        }
        else if (defenderBodyPart == BodyPart.None && attackerBodyPart == BodyPart.Body)
        {
            _animator.SetTrigger("GotInBody");
        }
        else if (defenderBodyPart == BodyPart.None && attackerBodyPart == BodyPart.Leg)
        {
            _animator.SetTrigger("GotInLegs");
        }
        else if (!forceDefence && defenderBodyPart == BodyPart.Head && attackerBodyPart == BodyPart.Body)
        {
            _animator.SetTrigger("DefendedHeadGotInBody");
        }
        else if(!forceDefence && defenderBodyPart == BodyPart.Head && attackerBodyPart == BodyPart.Leg)
        {
            _animator.SetTrigger("DefendedHeadGotInLegs");
        }
        else if(!forceDefence && defenderBodyPart == BodyPart.Body && attackerBodyPart == BodyPart.Head)
        {
            _animator.SetTrigger("DefendedBodyGotInHead");
        }
        else if (!forceDefence && defenderBodyPart == BodyPart.Body && attackerBodyPart == BodyPart.Leg)
        {
            _animator.SetTrigger("DefendedBodyGotInLegs");
        }
        else if (!forceDefence && defenderBodyPart == BodyPart.Leg && attackerBodyPart == BodyPart.Head)
        {
            _animator.SetTrigger("DefendedLegsGotInHead");
        }
        else if (!forceDefence && defenderBodyPart == BodyPart.Leg && attackerBodyPart == BodyPart.Body)
        {
            _animator.SetTrigger("DefendedLegsGotInBody");
        }
        else if (forceDefence && defenderBodyPart == BodyPart.Head && attackerBodyPart == BodyPart.Body)
        {
            _animator.SetTrigger("ForceDefendedHeadGotInBody");
        }
        else if (forceDefence && defenderBodyPart == BodyPart.Head && attackerBodyPart == BodyPart.Leg)
        {
            _animator.SetTrigger("ForceDefendedHeadGotInLegs");
        }
        else if (forceDefence && defenderBodyPart == BodyPart.Body && attackerBodyPart == BodyPart.Head)
        {
            _animator.SetTrigger("ForceDefendedBodyGotInHead");
        }
        else if (forceDefence && defenderBodyPart == BodyPart.Body && attackerBodyPart == BodyPart.Leg)
        {
            _animator.SetTrigger("ForceDefendedBodyGotInLegs");
        }
        else if (forceDefence && defenderBodyPart == BodyPart.Leg && attackerBodyPart == BodyPart.Head)
        {
            _animator.SetTrigger("ForceDefendedLegsGotInHead");
        }
        else if (forceDefence && defenderBodyPart == BodyPart.Leg && attackerBodyPart == BodyPart.Body)
        {
            _animator.SetTrigger("ForceDefendedLegsGotInBody");
        }
    }

    public void HitInBodyPart(bool forceAttack, BodyPart bodypart)
    {
        //spriteRend.sortingOrder = 1;
        if (!forceAttack)
        {
            switch (bodypart)
            {
                case BodyPart.Head:
                    _animator.SetTrigger("HitInHead");
                    break;

                case BodyPart.Body:
                    _animator.SetTrigger("HitInBody");
                    break;

                case BodyPart.Leg:
                    _animator.SetTrigger("HitInLegs");
                    break;
            }
        }
        else if(forceAttack)
        {
            switch (bodypart)
            {
                case BodyPart.Head:
                    _animator.SetTrigger("CounterattackHead");
                    break;

                case BodyPart.Body:
                    _animator.SetTrigger("CounterattackBody");
                    break;

                case BodyPart.Leg:
                    _animator.SetTrigger("CounterattackLegs");
                    break;
            }
        }
    }

    public void DefendedBodyPart(bool forceDefence, BodyPart bodypart)
    {
        //spriteRend.sortingOrder = 100;
        if (!forceDefence)
        {
            switch (bodypart)
            {
                case BodyPart.Head:
                    _animator.SetTrigger("DefendedHead");
                    break;

                case BodyPart.Body:
                    _animator.SetTrigger("DefendedBody");
                    break;

                case BodyPart.Leg:
                    _animator.SetTrigger("DefendedLegs");
                    break;
            }
        }
        else if(forceDefence)
        {
            switch (bodypart)
            {
                case BodyPart.Head:
                    _animator.SetTrigger("ForceDefendedHead");
                    break;

                case BodyPart.Body:
                    _animator.SetTrigger("ForceDefendedBody");
                    break;

                case BodyPart.Leg:
                    _animator.SetTrigger("ForceDefendedLegs");
                    break;
            }
        }
    }

    public void VictoryClip()
    {
        _animator.SetTrigger("Victory");
    }

    public void DeadClip()
    {
        _animator.SetTrigger("Dead");
    }
}
