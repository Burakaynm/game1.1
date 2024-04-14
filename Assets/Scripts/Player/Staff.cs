using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public Transform projectileSpawn;

    private float projectileSpeed = 30f;
    public float rpm;
    private float nextPossibleShootTime;
    public float secondsBetweenShots;

    private void Start()
    {
        secondsBetweenShots = 100 / rpm;
    }

    public void Shoot()
    {
        if (CanShoot())
        {
            GameObject projectileObj = ObjectPool.instance.GetPooledObj(0);
            projectileObj.transform.position = projectileSpawn.transform.position;
            projectileObj.transform.rotation = projectileSpawn.transform.rotation;
            projectileObj.SetActive(true);

            Rigidbody projectileRig = projectileObj.GetComponent<Rigidbody>();
            projectileRig.velocity = projectileSpawn.forward * projectileSpeed;
      
            nextPossibleShootTime = Time.time + secondsBetweenShots;
        }
    }

    private bool CanShoot()
    {
        return Time.time >= nextPossibleShootTime;
    }
}
