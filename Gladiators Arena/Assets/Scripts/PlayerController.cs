using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text playerHealthPoint;
    public int playerHealth = 100;
    public AttackType attackType = AttackType.Head;
    public DefenceType defenceType = DefenceType.Head;

    private void Update()
    {
       playerHealthPoint.text = playerHealth.ToString();
    }


    public void HeadAttack()
        {
            attackType = AttackType.Head;
            Debug.Log("Вы наносите удар в: " + attackType);
        }

        public void BodyAttack()
        {
            attackType = AttackType.Body;
            Debug.Log("Вы наносите удар в: " + attackType);
        }

        public void LegAttack()
        {
            attackType = AttackType.Leg;
            Debug.Log("Вы наносите удар в: " + attackType);
        }

        public void HeadDefence()
        {
            defenceType = DefenceType.Head;
            Debug.Log("Вы защищаете: " + defenceType);
        }

        public void BodyDefence()
        {
            defenceType = DefenceType.Body;
            Debug.Log("Вы защищаете: " + defenceType);
        }

        public void LegDefence()
        {
            defenceType = DefenceType.Leg;
            Debug.Log("Вы защищаете: " + defenceType);
        }
    }


public enum AttackType
{
    Head = 1,
    Body = 2,
    Leg = 3,
    HeadСounterattack = 4,
    BodyСounterattack = 5,
    LegСounterattack = 6
}

public enum DefenceType
{
    Head = 11,
    Body = 12,
    Leg = 13,
    HeadEnhancedProtection = 14,
    BodyEnhancedProtection = 15,
    LegEnhancedProtection = 16
}
