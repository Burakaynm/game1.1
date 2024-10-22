using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

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
        CharacterEvents.characterHealed.Invoke(gameObject, amount);

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
        StartCoroutine(RestartScene());
    }
    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(5);
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);    
    }
}
