using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    RectTransform rectTransform;

    public Vector3 moveSpeed = new Vector3(0,80,0);
    public float timeToFade = 1f;
    private float timeElapsed;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectTransform.position += moveSpeed * Time.deltaTime;
    }
}
