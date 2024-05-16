using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator animator;
    private EnemyController enemyController;
    private MageAttack mageAttack;

    public int startingHealth;
    public int currentHealth;

    public bool isAlive = true;


    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
        currentHealth = startingHealth;
    }

    private void OnEnable()
    {
        if (mageAttack)
        {
            Debug.Log("mage girdi");
            mageAttack.ThunderBolt.AddListener(TakeDamage);
        }
    }

    private void OnDisable()
    {
        if (mageAttack)
        {
            mageAttack.ThunderBolt.RemoveListener(TakeDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;
        CharacterEvents.characterDamaged.Invoke(gameObject, damage);

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
        enemyController.enabled = false;
        transform.position = transform.position;
        animator.SetBool("isAlive", false);
        animator.SetBool("isAttacking", false);
        Destroy(gameObject, 5f);
    }
}


