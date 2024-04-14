using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class MageAttack : MonoBehaviour
{
    public Staff staff;
    public Animator animator;
    public PlayerHealth health;
    [HideInInspector] public UnityEvent<int> ThunderBolt = new();

    public float shootingSpeed = 4f;
    private float baseMoveSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        baseMoveSpeed = PlayerController.moveSpeed;
    }

    void Update()
    {

        if (health.currentHealth > 0)
        {
            
            ShootMagic();
            PlayerUltimate();
        }
    }

    private void ShootMagic()
    {
        if (Input.GetMouseButton(0) /*|| Input.GetMouseButtonDown(1)*/)
        {
            PlayerController.moveSpeed = shootingSpeed;
            animator.SetFloat("AttackSpeed", PlayerController.attackSpeed);
            animator.SetBool("isShooting", true);
            animator.SetFloat("AttackNo", 0);
        }
        //else if (Input.GetMouseButtonDown(1))
        //{
        //    animator.SetFloat("AttackNo", 1);
        //}
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShooting", false);
            PlayerController.moveSpeed = baseMoveSpeed;
        }
    }

    public void MageAttackBase()
    {
        staff.Shoot();
    }

    private void PlayerUltimate()
    {
        if (Input.GetButtonDown("Ultimate"))
        {
            animator.SetTrigger("Ultimate");
            ThunderBolt.Invoke(100);
        }
    }
}
