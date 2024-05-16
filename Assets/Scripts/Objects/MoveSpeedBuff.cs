using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MoveSpeedBuff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;
    public float duration = 5f;  // Hýz artýþýnýn süresi

    public override void Apply(GameObject target, MonoBehaviour invoker)
    {
        invoker.StartCoroutine(ApplyBuff(target));
    }

    private IEnumerator ApplyBuff(GameObject target)
    {
        PlayerController.moveSpeed += amount;
        yield return new WaitForSeconds(duration);
        PlayerController.moveSpeed -= amount;
    }
}
