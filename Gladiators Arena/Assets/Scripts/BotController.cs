using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotController : MonoBehaviour
{
    public Text botHealthPoint;
    public int botHealth = 100;
    public BotAttack botAttack;
    public BotDefence botDefence;

    private void Update()
    {
        botHealthPoint.text = botHealth.ToString();
    }

    public void RandomBotAttack()
    {
        botAttack = (BotAttack)Random.Range(1, BotAttack.GetValues(typeof(BotAttack)).Length + 1);
        Debug.Log("Бот наносит удар в: " + botAttack);
    }

    public void RandomBotDefence()
    {
        botDefence = (BotDefence)Random.Range(1, BotDefence.GetValues(typeof(BotDefence)).Length + 1);
        Debug.Log("Бот защищает: " + botDefence); ;
    }
}


public enum BotAttack
{
    Head = 1,
    Body = 2,
    Leg = 3
}

public enum BotDefence
{
    Head = 1,
    Body = 2,
    Leg = 3
}