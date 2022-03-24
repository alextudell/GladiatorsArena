using System.Collections;
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

    [SerializeField] private SpriteRenderer _playerOne;
    [SerializeField] private SpriteRenderer _playerTwo;

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
            DoAttackAttack(player01, player02, _playerOne, _playerTwo);
            IsDead(player01, player02);
            yield return new WaitForSeconds(2.0f);
            DoAttackAttack(player02, player01, _playerTwo, _playerOne);
            IsDead(player01, player02);
            player01.Controller.Lock();
            player02.Controller.Lock();
            player01.Controller.Reset();
            player02.Controller.Reset();
            yield return new WaitForSeconds(3.0f);
            timer = turnDuration;

            player01.Controller.Unlock();
            player02.Controller.Unlock();
            yield return new WaitForSeconds(turnDuration);
            player01.ApplyTurn();
            player02.ApplyTurn();
            DoAttackAttack(player02, player01, _playerTwo, _playerOne);
            IsDead(player01, player02);
            yield return new WaitForSeconds(2.0f);
            DoAttackAttack(player01, player02, _playerOne, _playerTwo);
            IsDead(player01, player02);
            player01.Controller.Lock();
            player02.Controller.Lock();
            player01.Controller.Reset();
            player02.Controller.Reset();
            yield return new WaitForSeconds(3.0f);
            timer = turnDuration;

        }

        IsDead(player01, player02);
    }

    public void IsDead(Player playerOne, Player playerTwo)
    {
        if (playerOne.Murmillon.Health <= 0 || playerTwo.Murmillon.Health <= 0)
        { 
            enableTimer = false;
            StopCoroutine(Battle());
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
            Invoke("RestartLevel", 7f);
           
        }
    }

    public void DoAttackAttack(Player attacker, Player defender, SpriteRenderer attackPlayer, SpriteRenderer defencePlayer)
    {
        StartCoroutine(DoAttackAttackRoutine(attacker, defender, attackPlayer, defencePlayer));
    }

    public IEnumerator DoAttackAttackRoutine(Player attacker, Player defender, SpriteRenderer attackPlayer, SpriteRenderer defencePlayer)
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
            attackPlayer.sortingOrder = 10;
            defencePlayer.sortingOrder = 0;

            if (attacker.Murmillon.Health > 0 && defender.Murmillon.Health > 0)
            {
                if (counterattack && !forceDefence)
                {
                    attacker.Murmillon.AttackClip(counterattack, attackerBodyPart);
                    defender.Murmillon.ApplyDamage(counterattackDamageInfo);
                    defender.Murmillon.TakingDamageClip(!forceDefence, defenderBodyPart, attackerBodyPart);
                    //IsDead(attacker, defender);
                }
                else if (counterattack && forceDefence)
                {
                    attacker.Murmillon.AttackClip(!counterattack, attackerBodyPart);
                    defender.Murmillon.TakingDamageClip(forceDefence, defenderBodyPart, attackerBodyPart);
                    yield return null;
                    defender.Murmillon.ApplyDamage(forceDamageInfo);
                    //IsDead(attacker, defender);

                }
                else
                {
                    attacker.Murmillon.AttackClip(counterattack, attackerBodyPart);
                    defender.Murmillon.TakingDamageClip(forceDefence, defenderBodyPart, attackerBodyPart);
                    yield return null;
                    defender.Murmillon.ApplyDamage(damageInfo);
                    //IsDead(attacker, defender);
                }
            }
            else
            {
                IsDead(attacker, defender);
            }
        }
        
        if (defenderBodyPart == attackerBodyPart)
        {
            attackPlayer.sortingOrder = 0;
            defencePlayer.sortingOrder = 10;

            if (attacker.Murmillon.Health > 0 && defender.Murmillon.Health > 0)
            {
                if (forceDefence && !counterattack)
                {
                    attacker.Murmillon.AttackClip(counterattack, attackerBodyPart);
                    defender.Murmillon.DefendedClip(forceDefence, defenderBodyPart);
                    yield return null;
                    defender.Murmillon.AttackClip(!counterattack, defenderBodyPart);
                    attacker.Murmillon.TakingDamageClip(forceDefence, BodyPart.None, defenderBodyPart);
                    attacker.Murmillon.ApplyDamage(forceDamageInfo);
                    IsDead(attacker, defender);

                }
                else if (forceDefence && counterattack)
                {
                    attacker.Murmillon.AttackClip(!counterattack, attackerBodyPart);
                    defender.Murmillon.DefendedClip(forceDefence, defenderBodyPart);
                    yield return null;
                    defender.Murmillon.AttackClip(!counterattack, defenderBodyPart);
                    attacker.Murmillon.TakingDamageClip(forceDefence, BodyPart.None, defenderBodyPart);
                    attacker.Murmillon.ApplyDamage(forceDamageInfo);
                    IsDead(attacker, defender);
                }
                else
                {
                    attacker.Murmillon.AttackClip(counterattack, attackerBodyPart);
                    defender.Murmillon.DefendedClip(forceDefence, defenderBodyPart);
                }
            }
            else
            {
                IsDead(attacker, defender);
            }
        }
        
    }

    public void RestartLevel()
    {
        _restartlLevel.SetActive(true);
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