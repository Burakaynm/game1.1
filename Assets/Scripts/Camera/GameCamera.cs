using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Transform target;

    public float lerpSpeed = 0.25f;
    private float yAxisDef;

    public Vector3 offset = new();

    private void Start()
    {
        yAxisDef = transform.position.y;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 lerpPos = Vector3.Lerp(transform.position, target.position - offset, lerpSpeed * Time.deltaTime);

            lerpPos.y = yAxisDef;

            transform.position = lerpPos;
        }

    }
}


