using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Camera cam;
    private Transform character;
    public Rigidbody rb;
    [SerializeField] private LayerMask groundMask;

    //private Quaternion targetRotation;

    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float currSpeed;
    public float rotationSpeed = 2000f;

    Vector3 movement;

    public List<GameObject> characters = new();

    [HideInInspector] public UnityEvent<int> ThunderBolt = new();

    public bool x = false;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (x)
        {
            x = false;
            ThunderBolt.Invoke(15);
        }

        Move();

        Aim();
        //ControlMouse();
    }

    void FixedUpdate()
    {
        currSpeed = Input.GetButton("Run") ? runSpeed : walkSpeed;
        rb.MovePosition(rb.position + movement * currSpeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontal, 0f, vertical).normalized;

        #region
        //if (Input.GetKey(KeyCode.W))
        //{
        //    targetRotation = Quaternion.Euler(0, 0, 0);

        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        targetRotation = Quaternion.Euler(0, 45, 0);
        //    }
        //    else if (Input.GetKey(KeyCode.A))
        //    {
        //        targetRotation = Quaternion.Euler(0, -45, 0);
        //    }
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    targetRotation = Quaternion.Euler(0, 180, 0);

        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        targetRotation = Quaternion.Euler(0, 135, 0);
        //    }
        //    else if (Input.GetKey(KeyCode.A))
        //    {
        //        targetRotation = Quaternion.Euler(0, -135, 0);
        //    }
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    targetRotation = Quaternion.Euler(0, 90, 0);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    targetRotation = Quaternion.Euler(0, -90, 0);
        //}

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        #endregion


        if (animator != null)
        {
            if (movement != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                animator.SetBool("isRunning", Input.GetButton("Run"));
            }
            else
            {
                animator.SetBool("isMoving", false);
                animator.SetBool("isRunning", false);
            }
        }

    }

    //private void ControlMouse()
    //{
    //    mousePos = Input.mousePosition;

    //    mousePos = cam.ScreenToWorldPoint
    //        (new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));

    //    targetRotation = Quaternion.LookRotation
    //        (mousePos - new Vector3(transform.position.x, 0, transform.position.z));

    //    transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle
    //            (transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
    //}

    public void SelectClass(int characterIndex)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].gameObject.SetActive(false);
        }

        characters[characterIndex].SetActive(true);

        transform.root.gameObject.SetActive(true);

        animator = GetComponentInChildren<Animator>();

    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {

            var direction = position - transform.position;

            direction.y = 0;

            transform.forward = direction;
        }
    }
}

