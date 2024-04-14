using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        if (target.GetComponent<PlayerHealth>().currentHealth < target.GetComponent<PlayerHealth>().startingHealth)
        {
            target.GetComponent<PlayerHealth>().currentHealth += amount;
            if (target.GetComponent<PlayerHealth>().currentHealth > target.GetComponent<PlayerHealth>().startingHealth)
            {
                target.GetComponent<PlayerHealth>().currentHealth = target.GetComponent<PlayerHealth>().startingHealth;
            }
        }
    }
}
