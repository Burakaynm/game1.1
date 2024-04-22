using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    public HealthBar healthBar;

    public int startingHealth;
    public int currentHealth;

    private bool isAlive = true;

    public event Action<int> OnHealthChanged;


    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
    }


    public void TakeDamage(int damage)
    {
        if (!isAlive)
            return;

        currentHealth -= damage;
        CharacterEvents.characterDamaged.Invoke(gameObject, damage);
        healthBar.SetHealth(currentHealth);


        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Gethit"))
            animator.SetTrigger("GetHit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        if (!isAlive)
            return;

        currentHealth += amount;
        UpdateHealth(currentHealth);
        Debug.Log("can eklendi");

        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
    }
    private void UpdateHealth(int newHealth)
    {
        healthBar.SetHealth(newHealth);
        OnHealthChanged?.Invoke(newHealth);
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
