using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectDamageForBot : MonoBehaviour
{
    [SerializeField] private int healtPointsBot = 100;


    private void TakeDamage (int damage)
    {
        healtPointsBot -= damage;

        if(healtPointsBot <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
