using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance { get; private set; }
    public Text timerText;

    public Player player01;
    public Player player02;
    
    private float timer = 10;
    [SerializeField] [Range(0, 60)] private float turnDuration = 10;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(Battle());
    }

    private void Update()
    {
        timerText.text = Mathf.Ceil(timer).ToString();
        timer -= Time.deltaTime;
    }

    private IEnumerator Battle()
    {
        timer = turnDuration
            
            ;

        while (player01.Character.Health > 0 && player02.Character.Health > 0)
        {
            player01.Controller.Unlock();
            player02.Controller.Unlock();
            yield return new WaitForSeconds(turnDuration); // ������ ��� �����, ������ ��� ��� ������� �� ��������
            player01.ApplyTurn();
            player02.ApplyTurn();
            DoAttackAttack(player01, player02);
            DoAttackAttack(player02, player01);
            player01.Controller.Lock();
            player02.Controller.Lock();
            player01.Controller.Reset();
            player02.Controller.Reset();
            yield return new WaitForSeconds(1.0f);
            timer = turnDuration;
        }

        IsDead();
    }

    public void IsDead()
    {
        StopAllCoroutines();
        StopCoroutine(Battle());
    }

    public void DoAttackAttack(Player attacker, Player defender)
    {
        if (defender.TurnInfo.defenceBodyPart != attacker.TurnInfo.attackBodyPart)
            defender.Character.ApplyDamage(attacker.Character.AttackDamage);
    }
}