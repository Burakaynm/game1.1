using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator animator;
    private EnemyController enemyController;

    public int startingHealth;
    public int currentHealth;

    public bool isAlive = true;

    private PlayerController playerController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
        currentHealth = startingHealth;
    }

    private void OnEnable()
    {
        if(!playerController) playerController = FindObjectOfType<PlayerController>();

        playerController.ThunderBolt.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        playerController.ThunderBolt.RemoveListener(TakeDamage);
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("isHurt"))
        {
            animator.SetBool("isHurt", true);
            Invoke("Hurt", 1f);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }



    private void Hurt()
    {
        animator.SetBool("isHurt", false);
    }

    private void Die()
    {
        isAlive = false;
        animator.SetBool("isAlive", false);
        animator.SetBool("isAttacking", false);
        enemyController.enabled = false;
        transform.position = transform.position;
        Destroy(gameObject, 5f);
    }

}


