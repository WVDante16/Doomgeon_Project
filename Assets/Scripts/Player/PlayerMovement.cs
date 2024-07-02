using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables publicas
    public float speed = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    public LayerMask groundMask;

    //Variables privadas
    private CharacterController controller;
    private Vector3 velocity;
    private float gravity = -9.81f * 2;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Groundcheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        //Resetear la velocidad por defecto si esta en el suelo
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Obtener los inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector de movimiento
        Vector3 move = transform.right * x + transform.forward * z;

        //Mover al jugador
        controller.Move(move * speed * Time.deltaTime);

        //Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
