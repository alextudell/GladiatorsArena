using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Text timerText;
    public bool playerTurn;
    public PlayerController player;
    public BotController bot;
    [SerializeField] private int damage = 10;

    private GameObject[] rivals = new GameObject[2];
    [SerializeField] [Range(0, 60)] private float timer = 10;

    private void Awake()
    {
        rivals[0] = GameObject.FindGameObjectWithTag("Player");
        rivals[1] = GameObject.FindGameObjectWithTag("Bot");
    }

    void Start()
    {
        FirstMove();
        StartCoroutine(Battle());
    }

    private void Update()
    {
        timerText.text = Mathf.Ceil(timer).ToString();
        timer -= Time.deltaTime;
    }


    public void FirstMove()
    {
        var firstPlayer = rivals[Random.Range(0, rivals.Length)];
        if (firstPlayer = rivals[0])
        {
            playerTurn = true;
        }
        else
        {
            playerTurn = false;
        }
        Debug.Log("Первым ходит " + (playerTurn ? "игрок" : "компьютер"));
    }


    private IEnumerator Battle()
    {
        timer = 10f;

        while (player.playerHealth > 0 || bot.botHealth > 0)
        {
            if (playerTurn == true)
            {
                bot.RandomBotAttack();
                bot.RandomBotDefence();
                yield return new WaitForSeconds(10); // Сделал для теста, потому что мои условия не работали
                AttackConditions();
                DefenceConditions();
                playerTurn = false;
            }
            else
            {
                bot.RandomBotAttack();
                bot.RandomBotDefence();
                yield return new WaitForSeconds(10); // Сделал для теста, потому что мои условия не работали
                DefenceConditions();
                AttackConditions();
                playerTurn = true;
            }
        }

        IsDead();

    }

    public void IsDead()
    {
        StopAllCoroutines();
        StopCoroutine(Battle());
    }


    public void AttackConditions()
    {
        switch (player.attackType)
        {
            case AttackType.Head:
                {
                    if (bot.botDefence != BotDefence.Head)
                    {
                        //Проигрывается анимация удара в голову.
                        bot.botHealth -= damage;
                    }
                    else
                    {
                        //Проигрывается анимация отражения удара.
                    }
                }
                break;
            case AttackType.Body:
                {
                    if(bot.botDefence != BotDefence.Body)
                    {
                        //Проигрывается анимация удара в тело.
                        bot.botHealth -= damage;
                    }
                    else
                    {
                        //Проигрывается анимация отражения удара.
                    }

                }
                break;
            case AttackType.Leg:
                {
                    if(bot.botDefence != BotDefence.Leg)
                    {
                        //Проигрывается анимация удара в ногу.
                        bot.botHealth -= damage;
                    }
                    else
                    {
                        //Проигрывается анимация отражения удара.
                    }
                }
                break;
            case AttackType.HeadСounterattack:
                {
                    if (bot.botDefence != BotDefence.Head)
                    {
                        bot.botHealth -= (int)(damage * 1.5f);
                    }
                    else
                    {
                        //Проигрывается анимация отражения удара.
                    }
                }
                break;
            case AttackType.BodyСounterattack:
                {
                    if (bot.botDefence != BotDefence.Body)
                    {
                        bot.botHealth -= (int)(damage * 1.5f);
                    }
                    else
                    {
                        //Проигрывается анимация отражения удара.
                    }
                }
                break;
            case AttackType.LegСounterattack:
                {
                    if (bot.botDefence != BotDefence.Leg)
                    {
                        bot.botHealth -= (int)(damage * 1.5f);
                    }
                    else
                    {
                        //Проигрывается анимация отражения удара.
                    }
                }
                break;
        }
    }

    public void DefenceConditions()
    {
        switch (player.defenceType)
        {
            case DefenceType.Head:
                {
                    if(bot.botAttack == BotAttack.Head)
                    {
                        //Проигрывается анимация отражения удара
                    }
                    else
                    {
                        player.playerHealth -= damage;
                    }
                }
                break;
            case DefenceType.Body:
                {
                    if (bot.botAttack == BotAttack.Body)
                    {
                        //Проигрывается анимация отражения удара
                    }
                    else
                    {
                        player.playerHealth -= damage;
                    }
                }
                break;
            case DefenceType.Leg:
                {
                    if (bot.botAttack == BotAttack.Leg)
                    {
                        //Проигрывается анимация отражения удара
                    }
                    else
                    {
                        player.playerHealth -= damage;
                    }
                }
                break;
            case DefenceType.HeadEnhancedProtection:
                {
                    if (bot.botAttack == BotAttack.Head)
                    {
                        //Сначала проигрывается анимация отражения удара, затем атаки
                        bot.botHealth -= damage * 2;
                    }
                    else
                    {
                        player.playerHealth -= damage;
                    }
                }
                break;
            case DefenceType.BodyEnhancedProtection:
                {
                    if (bot.botAttack == BotAttack.Body)
                    {
                        //Сначала проигрывается анимация отражения удара, затем атаки
                        bot.botHealth -= damage * 2;
                    }
                    else
                    {
                        player.playerHealth -= damage;
                    }
                }
                break;
            case DefenceType.LegEnhancedProtection:
                {
                    if (bot.botAttack == BotAttack.Leg)
                    {
                        //Сначала проигрывается анимация отражения удара, затем атаки
                        bot.botHealth -= damage * 2;
                    }
                    else
                    {
                        player.playerHealth -= damage;
                    }
                }
                break;
            default:
                break;
        }

    }

}