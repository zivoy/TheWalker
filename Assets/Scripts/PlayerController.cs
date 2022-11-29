using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float jumpHeight = 3f;

    public float groundDistance = 0.01f; // maybe use tags for ground

    public Interaction focus;

    [NonSerialized] public float gravity;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance);
        Debug.DrawLine(transform.position, transform.position+Vector3.down*groundDistance);

        // if (isGrounded && velocity.y < 0)
        // {
            // velocity.y = -2f;
        // }

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}