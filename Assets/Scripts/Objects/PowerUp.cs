using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;
    public GameObject collectEffect;

    public float rotationSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            powerUpEffect.Apply(other.gameObject, this);
            if (collectEffect)
                Instantiate(collectEffect, transform.position, Quaternion.identity);
        }
    }
    private void OnEnable()
    {
        Destroy(gameObject, 10);
    }
}
