using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAttack : MonoBehaviour
{
    public EnemyController enemyController;
    public EnemyData enemyData;
    public Animator animator;
    public EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;

    private bool isKilled; // Dont attack when player is dead



    private void Start()
    {
        isKilled = false;
        
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }
    private void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("GetHit")) return;

        if (enemyController.currDistance <= enemyData.attackRange && !isKilled)
        {
            enemyController.currSpeed = 0;  //Stop when hitting 
            animator.SetBool("isAttacking", true);
        }
        else
        {
            enemyController.currSpeed = enemyData.speed;
            animator.SetBool("isAttacking", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(!playerHealth) { return; }

        if (other.CompareTag("Player"))
        {
            if (playerHealth.currentHealth <= 0)
            {
                isKilled = true;
                animator.SetBool("Victory", true);
                animator.SetBool("isAttacking", false); // Saldýrýyý durdur
                enemyController.enabled = false;
            }
            else if (!isKilled && playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(enemyData.damage);
            }
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        enemyController.currSpeed = enemyData.speed;
        animator.SetBool("isAttacking", false);
    }

}
