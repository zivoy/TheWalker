using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private const float YMin = -10.0f;
    private const float YMax = 50.0f;
 
    public Vector3 offset;
 
    public Transform player;
 
    public float distance = 10;
    private Vector2 current;
    public float sensivity = 1000;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void LateUpdate()
    {
        current.x += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        current.y += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
 
        current.y = Mathf.Clamp(current.y, YMin, YMax);
 
        // adjust camera
        var direction = new Vector3(0, 0, -distance);
        var rotation = Quaternion.Euler(current.y, current.x, 0);
        var origin = player.position + offset; 
        transform.position = origin + rotation * direction;
        transform.LookAt(origin);
 
        // adjust player
        var camRotation = transform.rotation;
        camRotation.x = 0f;
        camRotation.z = 0f;
        player.rotation = Quaternion.Lerp(player.rotation, camRotation, 0.1f);
    }
}
