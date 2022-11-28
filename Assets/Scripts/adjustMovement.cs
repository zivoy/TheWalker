using System;
using UnityEditor;
using UnityEngine;

// gets controlled by special colliders

public class adjustMovement : MonoBehaviour
{
    [Header("Movement adjustors")]

    [Tooltip("Gravity strength as a number")] 
    public float gravity = 9.81f;

    [Min(.001f), Tooltip("Movement speed multiplier, augments the stock movement speed")]
    public float speedMultiplier = 1f;

    // used so that the gravity method doesnt get spammed, only call on change
    private float _lastGrav;
    private float _lastSpeedMul;

    // the default speed that can be used with the multiplier
    private float _defaultSpeed;
    
    // the actual movement script
    private Charactermove _movementController;
    
    private void Start()
    {
        _movementController = gameObject.GetComponent<Charactermove>();
        _defaultSpeed = _movementController.Speed;
    }

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
        
        if (Math.Abs(speedMultiplier - _lastSpeedMul) > .001f) // update if change is bigger then float errors 
        {
            _movementController.Speed = speedMultiplier * _defaultSpeed;
            _lastSpeedMul = speedMultiplier;
        }
    }
}