using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/AttackSpeedBuff")]
public class AttackSpeedBuff : PowerUpEffect
{
    public float amount;
    public float duration = 5f; // Hýz artýþýnýn süresi
    public override void Apply(GameObject target, MonoBehaviour invoker)
    {
            invoker.StartCoroutine(ApplyBuff(target));
        //PlayerController.attackSpeed += amount;
    }

    private IEnumerator ApplyBuff(GameObject target)
    {
        PlayerController.attackSpeed += amount;
        yield return new WaitForSeconds(duration);
        PlayerController.attackSpeed -= amount;
    }
    
}
