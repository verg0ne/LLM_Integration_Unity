using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f; // Adjust this value to change the speed of movement

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the object up and down continuously
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}