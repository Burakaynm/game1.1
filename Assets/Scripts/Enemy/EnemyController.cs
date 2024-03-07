using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject playerObject;

    public EnemyData enemyData; 

    //private EnemyHealth enemyHealth;

    public float currDistance = 0f;
    public float currSpeed;

    private Vector3 target;
    private Vector3 playerDirection;

    public EnemyRangedAttack rangedAttack;

    private void Start()
    {
        //enemyHealth = GetComponent<EnemyHealth>();
        //enemyHealth.startingHealth = 200;
        currSpeed = enemyData.speed;
    }

    private void Update()
    {
        if (playerObject != null)
        {
            FollowPlayer();  
        }
        else
        {
            currSpeed = 0;
        }
    }

    public void FollowPlayer()
    {
        
        playerDirection = new Vector3   // Found player's location
            (playerObject.transform.position.x - transform.position.x, playerObject.transform.position.y - transform.position.y, playerObject.transform.position.z - transform.position.z);

        target = playerObject.transform.position;

        currDistance = Vector3.Distance(target, transform.position);    //Distance 

        transform.position = Vector3.MoveTowards(transform.position, target, currSpeed);    //Make enemy follow the player

        transform.LookAt(target);

        if (currDistance > enemyData.followDistance)
        {
            Destroy(gameObject);
        }
    }

    public void LichAttackBase()
    {
        rangedAttack.LichAttack();
    }
}



