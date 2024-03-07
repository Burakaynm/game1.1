using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerProjectile : MonoBehaviour
{
    private int projectileDamage = 15;

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (other.CompareTag("Enemy"))
        {
            enemyHealth.TakeDamage(projectileDamage);
            gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        StartCoroutine(DeactivateAfterTime(3f)); 
    }

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time); 
        gameObject.SetActive(false); 
    }
}
