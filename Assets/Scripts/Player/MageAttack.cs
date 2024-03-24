using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MageAttack : MonoBehaviour
{
    public Staff staff;
    public Animator animator;
    public PlayerHealth health;

    //private int pushDamage = 5;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health.currentHealth > 0)
        {
            //ControlMouse();
            ShootMagic();
            PlayerInteract();
        }
    }

    private void ShootMagic()
    {
        if (Input.GetButtonDown("IncAttackSpeed"))
        {
            PlayerController.attackSpeed++;
        }
        else if (Input.GetButtonDown("DecAttackSpeed"))
        {
            if (PlayerController.attackSpeed > 1)
            {
                PlayerController.attackSpeed--;
            }
        }

        if (Input.GetMouseButton(0) /*|| Input.GetMouseButtonDown(1)*/)
        {
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
        }

    }

    public void MageAttackBase()
    {
        staff.Shoot();
    }

    private void PlayerInteract()
    {
        if (Input.GetButtonDown("Interact"))
        {
            animator.SetTrigger("Interact");
        }
    }
}
