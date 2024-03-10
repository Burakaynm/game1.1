using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MageAttack : MonoBehaviour
{
    private Camera cam;
    public Staff staff;
    public Animator animator;
    public PlayerHealth health;

    private Quaternion targetRotation;
    Vector3 input;
    Vector3 mousePos;

    public float rotationSpeed = 1000f;
    //private int pushDamage = 5;
    private float attackSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
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
            attackSpeed++;
        }
        else if (Input.GetButtonDown("DecAttackSpeed"))
        {
            if (attackSpeed > 1)
            {
                attackSpeed--;
            }
        }

        if (Input.GetMouseButton(0) /*|| Input.GetMouseButtonDown(1)*/)
        {
            animator.SetFloat("AttackSpeed", attackSpeed);
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
