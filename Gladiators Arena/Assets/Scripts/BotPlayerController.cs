using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPlayerController : PlayerController
{
    public override TurnInfo GetTurn()
    {
        var turn = new TurnInfo();
        turn.attackBodyPart = (BodyPart)Random.Range(1, 4);
        turn.defenceBodyPart = (BodyPart)Random.Range(1, 4);
        return turn;
    }
}
