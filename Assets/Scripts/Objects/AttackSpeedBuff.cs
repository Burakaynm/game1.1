using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/AttackSpeedBuff")]
public class AttackSpeedBuff : PowerUpEffect
{
    public float amount;
    public float baseAttackSpeed = PlayerController.attackSpeed;

    public override void Apply(GameObject target)
    {
        PlayerController.attackSpeed += amount;       
    }
}
