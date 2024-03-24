using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            powerUpEffect.Apply(other.gameObject);
        }
    }
    private void OnEnable()
    {
        Destroy(gameObject, 20);
    }
}
