using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    [HideInInspector] public UnityEvent<int> ThunderBolt = new();

    private bool canInteract = false;

    private void Update()
    {
        if (canInteract) Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            Debug.Log("true");
        }
    }

    public void Interact()
    {
        if (Input.GetButtonDown("Interact"))
        {
            ThunderBolt.Invoke(10);
            Debug.Log("Thunder2");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            Debug.Log("false");
        }
    }
}
