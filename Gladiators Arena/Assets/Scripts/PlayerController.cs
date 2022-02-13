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
            Debug.Log("�� �������� ���� �: " + attackType);
        }

        public void BodyAttack()
        {
            attackType = AttackType.Body;
            Debug.Log("�� �������� ���� �: " + attackType);
        }

        public void LegAttack()
        {
            attackType = AttackType.Leg;
            Debug.Log("�� �������� ���� �: " + attackType);
        }

        public void HeadDefence()
        {
            defenceType = DefenceType.Head;
            Debug.Log("�� ���������: " + defenceType);
        }

        public void BodyDefence()
        {
            defenceType = DefenceType.Body;
            Debug.Log("�� ���������: " + defenceType);
        }

        public void LegDefence()
        {
            defenceType = DefenceType.Leg;
            Debug.Log("�� ���������: " + defenceType);
        }
    }


public enum AttackType
{
    Head = 1,
    Body = 2,
    Leg = 3,
    Head�ounterattack = 4,
    Body�ounterattack = 5,
    Leg�ounterattack = 6
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
