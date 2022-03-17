using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance { get; private set; }
    public Text timerText;

    public Player player01;
    public Player player02;

    public GameObject atakue;
    
    private float timer = 10;
    [SerializeField] [Range(0, 60)] private float turnDuration = 10;

    [SerializeField] private GameObject _restartlLevel;

    private bool enableTimer = true;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _restartlLevel.SetActive(false);
        StartCoroutine(Battle());
    }

    private void Update()
    {
        timerText.text = Mathf.Ceil(Mathf.Clamp(timer, 0, 9999)).ToString();

        if(enableTimer)
        {
            timer -= Time.deltaTime;
        }
        
    }

    private IEnumerator Battle()
    {
        timer = turnDuration;

        while (player01.Murmillon.Health > 0 && player02.Murmillon.Health > 0)
        {
            player01.Controller.Unlock();
            player02.Controller.Unlock();
            yield return new WaitForSeconds(turnDuration);
            player01.ApplyTurn();
            player02.ApplyTurn();
            DoAttackAttack(player01, player02);
            yield return new WaitForSeconds(2.0f);
            DoAttackAttack(player02, player01);
            player01.Controller.Lock();
            player02.Controller.Lock();
            player01.Controller.Reset();
            player02.Controller.Reset();
            yield return new WaitForSeconds(4.0f);
            
            if(player01.Murmillon.Health <= 0 || player02.Murmillon.Health <= 0)
            {
                IsDead(player01, player02);
                StopCoroutine(Battle());
            }

            timer = turnDuration;

            player01.Controller.Unlock();
            player02.Controller.Unlock();
            yield return new WaitForSeconds(turnDuration);
            player01.ApplyTurn();
            player02.ApplyTurn();
            DoAttackAttack(player02, player01);
            yield return new WaitForSeconds(2.0f);
            DoAttackAttack(player01, player02);
            player01.Controller.Lock();
            player02.Controller.Lock();
            player01.Controller.Reset();
            player02.Controller.Reset();
            yield return new WaitForSeconds(4.0f);
            timer = turnDuration;

        }

        IsDead(player01, player02);
    }

    public void IsDead(Player playerOne, Player playerTwo)
    {
        enableTimer = false;
        _restartlLevel.SetActive(true);

        if(playerOne.Murmillon.Health <= 0)
        {
            playerOne.Murmillon.DeadClip();
            playerTwo.Murmillon.VictoryClip();
        }
        else if(playerTwo.Murmillon.Health <=0)
        {
            playerTwo.Murmillon.DeadClip();
            playerOne.Murmillon.VictoryClip();
        }
    }

    public void DoAttackAttack(Player attacker, Player defender)
    {
        StartCoroutine(DoAttackAttackRoutine(attacker, defender));
    }

    public IEnumerator DoAttackAttackRoutine(Player attacker, Player defender)
    {
        var defenderBodyPart = defender.TurnInfo.defenceBodyPart;
        var attackerBodyPart = attacker.TurnInfo.attackBodyPart;

        var attackDamage = attacker.Murmillon.AttackDamage;
        var forceAttackDamage = attacker.Murmillon.ForceAttackDamage;
        var counterattackDamage = attacker.Murmillon.CounterattackDamage;

        var damageInfo = new DamageInfo(attackDamage, attackerBodyPart);
        var forceDamageInfo = new DamageInfo(forceAttackDamage, attackerBodyPart);
        var counterattackDamageInfo = new DamageInfo(counterattackDamage, attackerBodyPart); 

        bool counterattack = attacker.TurnInfo.forceAttack;
        bool forceDefence = defender.TurnInfo.forceDefence;

        if (attackerBodyPart == BodyPart.None)
        {
            yield break;
        }

        if (defenderBodyPart != attackerBodyPart)
        {
            if (counterattack && !forceDefence)
            {
                attacker.Murmillon.AttackClip(counterattack, attackerBodyPart);
                defender.Murmillon.ApplyDamage(counterattackDamageInfo);
                defender.Murmillon.TakingDamageClip(!forceDefence, defenderBodyPart, attackerBodyPart);
            }
            else if (counterattack && forceDefence)
            {
                attacker.Murmillon.AttackClip(!counterattack, attackerBodyPart);
                defender.Murmillon.TakingDamageClip(forceDefence, defenderBodyPart, attackerBodyPart);
                yield return null;
                //defender.Murmillon.AttackClip(forceAttack, attackerBodyPart);
                defender.Murmillon.ApplyDamage(forceDamageInfo);

            }
            else
            {
                attacker.Murmillon.AttackClip(counterattack, attackerBodyPart);
                defender.Murmillon.TakingDamageClip(forceDefence, defenderBodyPart, attackerBodyPart);
                yield return null;
                defender.Murmillon.ApplyDamage(damageInfo);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        if (defenderBodyPart == attackerBodyPart)
        {
            if (forceDefence && !counterattack)
            {
                attacker.Murmillon.AttackClip(counterattack, attackerBodyPart);
                defender.Murmillon.DefendedClip(forceDefence, defenderBodyPart);
                yield return null;
                defender.Murmillon.AttackClip(!counterattack, defenderBodyPart);
                attacker.Murmillon.TakingDamageClip(forceDefence, BodyPart.None, defenderBodyPart);
                attacker.Murmillon.ApplyDamage(forceDamageInfo);
            }
            else if (forceDefence && counterattack)
            {
                attacker.Murmillon.AttackClip(!counterattack, attackerBodyPart);
                defender.Murmillon.DefendedClip(forceDefence, defenderBodyPart);
                yield return null;
                defender.Murmillon.AttackClip(!counterattack, defenderBodyPart);
                attacker.Murmillon.TakingDamageClip(forceDefence, BodyPart.None, defenderBodyPart);
                attacker.Murmillon.ApplyDamage(forceDamageInfo);
            }
            else
            {
                attacker.Murmillon.AttackClip(counterattack, attackerBodyPart);
                defender.Murmillon.DefendedClip(forceDefence, defenderBodyPart);
                //return;
            }
        }





        
    }

    public void RestartBattle()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}