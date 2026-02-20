using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveHighlightBehavior : MonoBehaviour
{
    private float moveSpeed = 4f;
    private float amplitude = 0.2f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float newY = originalPosition.y + amplitude * Mathf.Sin(Time.time * moveSpeed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
