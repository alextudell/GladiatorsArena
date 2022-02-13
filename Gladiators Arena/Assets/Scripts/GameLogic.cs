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
        Debug.Log("������ ����� " + (playerTurn ? "�����" : "���������"));
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
                yield return new WaitForSeconds(10); // ������ ��� �����, ������ ��� ��� ������� �� ��������
                AttackConditions();
                DefenceConditions();
                playerTurn = false;
            }
            else
            {
                bot.RandomBotAttack();
                bot.RandomBotDefence();
                yield return new WaitForSeconds(10); // ������ ��� �����, ������ ��� ��� ������� �� ��������
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
                        //������������� �������� ����� � ������.
                        bot.botHealth -= damage;
                    }
                    else
                    {
                        //������������� �������� ��������� �����.
                    }
                }
                break;
            case AttackType.Body:
                {
                    if(bot.botDefence != BotDefence.Body)
                    {
                        //������������� �������� ����� � ����.
                        bot.botHealth -= damage;
                    }
                    else
                    {
                        //������������� �������� ��������� �����.
                    }

                }
                break;
            case AttackType.Leg:
                {
                    if(bot.botDefence != BotDefence.Leg)
                    {
                        //������������� �������� ����� � ����.
                        bot.botHealth -= damage;
                    }
                    else
                    {
                        //������������� �������� ��������� �����.
                    }
                }
                break;
            case AttackType.Head�ounterattack:
                {
                    if (bot.botDefence != BotDefence.Head)
                    {
                        bot.botHealth -= (int)(damage * 1.5f);
                    }
                    else
                    {
                        //������������� �������� ��������� �����.
                    }
                }
                break;
            case AttackType.Body�ounterattack:
                {
                    if (bot.botDefence != BotDefence.Body)
                    {
                        bot.botHealth -= (int)(damage * 1.5f);
                    }
                    else
                    {
                        //������������� �������� ��������� �����.
                    }
                }
                break;
            case AttackType.Leg�ounterattack:
                {
                    if (bot.botDefence != BotDefence.Leg)
                    {
                        bot.botHealth -= (int)(damage * 1.5f);
                    }
                    else
                    {
                        //������������� �������� ��������� �����.
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
                        //������������� �������� ��������� �����
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
                        //������������� �������� ��������� �����
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
                        //������������� �������� ��������� �����
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
                        //������� ������������� �������� ��������� �����, ����� �����
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
                        //������� ������������� �������� ��������� �����, ����� �����
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
                        //������� ������������� �������� ��������� �����, ����� �����
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