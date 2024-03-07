using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public EnemyData enemyData;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(enemyData.damage);
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
