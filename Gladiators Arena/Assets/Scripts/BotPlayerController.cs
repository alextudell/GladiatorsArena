using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPlayerController : PlayerController
{
    public override TurnInfo GetTurn()
    {
        var turn = new TurnInfo();
        int randomForcedAction = Random.Range(1, 10);

        if (randomForcedAction == 1)
        {
            turn.attackBodyPart = (BodyPart)Random.Range(1, 4);
            turn.forceAttack = true;
        }
        else if (randomForcedAction == 2)
        {
            turn.defenceBodyPart = (BodyPart)Random.Range(1, 4);
            turn.forceDefence = true;
        }
        else
        {
            turn.attackBodyPart = (BodyPart)Random.Range(1, 4);
            turn.defenceBodyPart = (BodyPart)Random.Range(1, 4);
        }

        return turn;
    }
}
