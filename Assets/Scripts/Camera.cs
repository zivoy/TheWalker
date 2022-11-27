using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    void Update()
    {
        transform.position = Player.position + offset;
    }
}

