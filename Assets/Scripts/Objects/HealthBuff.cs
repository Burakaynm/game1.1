using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public int amount;

    public override void Apply(GameObject target)
    {
        var playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth.currentHealth < playerHealth.startingHealth)
        {
            playerHealth.AddHealth(amount);

            if (playerHealth.currentHealth > playerHealth.startingHealth)
            {
                playerHealth.currentHealth = playerHealth.startingHealth;
            }
        }
    }
}
