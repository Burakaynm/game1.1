using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;

    public int startingHealth;
    public float currentHealth;

    private bool isAlive = true;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
        currentHealth = startingHealth;
    }


    public void TakeDamage(float damage)
    {
        if (!isAlive)
            return;

        currentHealth -= damage;
        CharacterEvents.characterDamaged.Invoke(gameObject, damage);


        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Gethit"))
            animator.SetTrigger("GetHit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        animator.SetBool("isAlive", false);
        playerController.enabled = false;
        transform.position = transform.position;
        Destroy(gameObject, 5f);
    }


}
