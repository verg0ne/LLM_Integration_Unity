using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_CONTROLLER : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = 9.81f;
    public float rotationSpeed = 10f;
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D o Frecce sinistra/destra
        float moveZ = Input.GetAxis("Vertical");   // W/S o Frecce su/giù

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        if (move.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        controller.Move(move * moveSpeed * Time.deltaTime);

        // Applicare gravità
        if (!controller.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -2f; // Mantiene il personaggio incollato al suolo
        }

        controller.Move(velocity * Time.deltaTime);
    }
}


