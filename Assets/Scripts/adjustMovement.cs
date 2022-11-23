using System;
using UnityEngine;

// gets controlled by special colliders

public class adjustMovement : MonoBehaviour
{
    [Header("Movement controls")]
    [Min(.001f), Tooltip("Movement speed")]
    public float speed = 1f;

    [Tooltip("Gravity strength")] 
    public float gravity = 9.81f;
    
    // used so that the gravity method doesnt get spammed, only call on change
    private float _lastGrav;
    private float _lastSpeed;

    // Update is called once per frame
    void Update()
    {
        // only update when players gravity changed
        if (Math.Abs(gravity - _lastGrav) > .001f) // update if change is bigger then float errors 
        {
            // update gravity
            Physics.gravity = new Vector3(0, -gravity, 0);
            // update last
            _lastGrav = gravity;
        }
        
        if (Math.Abs(speed - _lastSpeed) > .001f) // update if change is bigger then float errors 
        {
            // todo - update speed in movement script
            _lastSpeed = speed;
        }
    }
}