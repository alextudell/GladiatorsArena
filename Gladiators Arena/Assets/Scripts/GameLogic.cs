using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance { get; private set; }
    public Text timerText;

    public Player player01;
    public Player player02;
    
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
        timerText.text = Mathf.Ceil(timer).ToString();

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
            yield return new WaitForSeconds(1.0f);
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
            yield return new WaitForSeconds(1.0f);
            timer = turnDuration;
        }

        IsDead();
    }

    public void IsDead()
    {
        enableTimer = false;
        _restartlLevel.SetActive(true);
    }

    public void DoAttackAttack(Player attacker, Player defender)
    {
        var defenderBodyPart = defender.TurnInfo.defenceBodyPart;
        var attackerBodyPart = attacker.TurnInfo.attackBodyPart;

        bool forceAttack = attacker.TurnInfo.forceAttack;
        bool forceDefence = defender.TurnInfo.forceDefence;

        bool hasDamagae = true;
        bool hasDefence = true;

        if (defenderBodyPart != attacker.TurnInfo.attackBodyPart)
        {
            if (attacker.TurnInfo.attackBodyPart == BodyPart.None)
            {
                //var damageInfo = new DamageInfo(attacker.Murmillon.ForceAttackDamage, attacker.TurnInfo.attackBodyPart);
                //defender.Murmillon.TakingDamageClip(damageInfo);
                return;
            }
            else if(forceAttack && !forceDefence)
            {
                var damageInfo = new DamageInfo(attacker.Murmillon.ForceAttackDamage, attacker.TurnInfo.attackBodyPart);

                attacker.Murmillon.ApplyDamage(forceAttack, hasDamagae, damageInfo);
                defender.Murmillon.TakingDamageClip(!forceDefence, hasDefence, defenderBodyPart, attackerBodyPart);
            }
            else if (forceAttack && forceDefence)
            {
                var damageInfo = new DamageInfo(attacker.Murmillon.ForceAttackDamage, attacker.TurnInfo.attackBodyPart);

                attacker.Murmillon.ApplyDamage(forceAttack, !hasDamagae, damageInfo);
                defender.Murmillon.TakingDamageClip(forceDefence, hasDefence, defenderBodyPart, attackerBodyPart);
                defender.Murmillon.ApplyDamage(forceAttack, hasDamagae, damageInfo);

            }
            else
            {
                var damageInfo = new DamageInfo(attacker.Murmillon.AttackDamage, attacker.TurnInfo.attackBodyPart);

                attacker.Murmillon.ApplyDamage(!forceAttack, hasDamagae, damageInfo);
                defender.Murmillon.TakingDamageClip(!forceDefence, hasDefence, defenderBodyPart, attackerBodyPart);
            }
        }

        if (defenderBodyPart == attacker.TurnInfo.attackBodyPart)
        {
            if (forceDefence && !forceAttack)
            {
                var damageInfo = new DamageInfo(attacker.Murmillon.AttackDamage * 2, attacker.TurnInfo.attackBodyPart);

                attacker.Murmillon.ApplyDamage(!forceAttack, !hasDamagae, damageInfo);
                defender.Murmillon.DefendedClip(forceDefence, defenderBodyPart);
                defender.Murmillon.ApplyDamage(forceAttack, forceDefence, damageInfo);
            }
            else if (forceDefence && forceAttack)
            {
                var damageInfo = new DamageInfo(attacker.Murmillon.AttackDamage * 2, attacker.TurnInfo.attackBodyPart);

                attacker.Murmillon.ApplyDamage(forceAttack, !hasDamagae, damageInfo);
                defender.Murmillon.DefendedClip(forceDefence, defenderBodyPart);
                defender.Murmillon.ApplyDamage(forceAttack, forceDefence, damageInfo);
            }
            else
            {
                var damageInfo = new DamageInfo(attacker.Murmillon.AttackDamage, attacker.TurnInfo.attackBodyPart);

                attacker.Murmillon.ApplyDamage(!forceAttack, !hasDamagae, damageInfo);
                defender.Murmillon.DefendedClip(!forceDefence, defenderBodyPart);
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