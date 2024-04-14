using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyRangedAttack : MonoBehaviour
{
    public EnemyController enemyController;
    public EnemyData enemyData;
    public Animator animator;
    public Transform spawnPoint;
    public PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;
    [SerializeField] private ObjectPool objectPool;


    private float attackInterval = 1.1f;
    private float timer;
    private float projectileSpeed = 15f;

    private bool inRange = false;
    private bool firstAnim = true;

    private void Update()
    {
        if (inRange && enemyHealth.isAlive) ShootAtPlayer();
    }
    void ShootAtPlayer()
    {
        timer -= Time.deltaTime;


        if (timer > 0) return;

        timer = firstAnim ? 0.2f : attackInterval;

        enemyController.currSpeed = 0;
        animator.SetBool("isAttacking", true);
    }

    public void LichAttack()
    {
        GameObject projectileObj = ObjectPool.instance.GetPooledObj(1);
        projectileObj.transform.position = spawnPoint.transform.position;
        projectileObj.transform.rotation = spawnPoint.transform.rotation;
        projectileObj.SetActive(true);

        Rigidbody projectileRig = projectileObj.GetComponent<Rigidbody>();
        projectileRig.velocity = projectileRig.transform.forward * projectileSpeed;

        firstAnim = false;

        if (playerHealth.currentHealth <= 0)
        {
            animator.SetBool("Victory", true);
            animator.SetBool("isAttacking", false);
            enemyController.enabled = false;
            inRange = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyController.currSpeed = enemyData.speed;
            animator.SetBool("isAttacking", false);
            inRange = false;
            firstAnim = true;
        }
    }

}
