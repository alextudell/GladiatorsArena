using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;

    public void GotInHead(Player attacker, Player defender)
    {
        if (defender.TurnInfo.defenceBodyPart != attacker.TurnInfo.attackBodyPart)
        {
            animator.SetBool("GotInHead", true);
        }

    }
}
