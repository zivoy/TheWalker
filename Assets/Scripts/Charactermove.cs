using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermove : MonoBehaviour
{

    public float smoothing;
    public Vector3 PlayerMovementInput;
    public Transform m_transform;
    public float rotationspeed;


    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivty;
    [SerializeField] private float Jumpforce;

    void Start()
    {
        m_transform = this.m_transform;
    }
    void Update()
    {

       
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovePlayer();

    }
    private void MovePlayer()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            m_transform.Rotate(0.0f, rotationspeed*-1, 0.0f, Space.Self);
            m_transform.Translate(Vector3.left * Time.deltaTime * Speed);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_transform.Rotate(0.0f, rotationspeed, 0.0f, Space.Self);
            m_transform.Translate(Vector3.right * Time.deltaTime * Speed);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }
    }

}