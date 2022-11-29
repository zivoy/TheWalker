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

    bool IsGrounded()
    {
        var pos = transform.position;
        Debug.DrawLine(pos, pos + Vector3.down * groundDistance);
        return Physics.Raycast(pos, Vector3.down, groundDistance) && gravity < 0;
    }

    void Update()
    {
        if (controller.isGrounded) velocity.y = 0;

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && IsGrounded()) // there is a bug where you cant jump when on the edge of a block
        {
            Debug.Log("jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}