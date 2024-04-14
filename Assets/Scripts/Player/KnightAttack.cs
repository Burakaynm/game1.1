using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class KnightAttack : MonoBehaviour
{
    public Animator animator;
    public PlayerHealth health;

    private int lightDamage = 10;
    private int heavyDamage = 20;
    private int damage;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        Attack();
        //PlayerInteract();

    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
            if (Input.GetMouseButtonDown(0))
            {
                damage = lightDamage;
                animator.SetFloat("AttackNo", 0);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                damage = heavyDamage;
                animator.SetFloat("AttackNo", 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

    }

    //private void PlayerInteract()
    //{
    //    if (Input.GetButtonDown("Ultimate"))
    //    {
    //        animator.SetTrigger("Ultimate");
    //    }
    //}
}
