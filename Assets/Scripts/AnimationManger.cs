using System;
using UnityEngine;

public class AnimationManger : MonoBehaviour
{
    public Animator animationController;
    private PlayerController _movementController;

    [Header("Speed thresholds")] public float walkingRunningCutoff = 3f;

    private readonly string _currentStateName = "Current State";
    private readonly string _speedVarName = "Speed";

    void Start()
    {
        _movementController = gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        UpdateRunningAnimation();
    }

    void UpdateRunningAnimation()
    {
        //  make rotation animation
        var forwardSpeed = Input.GetAxis("Vertical"); 
        int state = 0;
        float speed = 1;
        if (forwardSpeed != 0)
        {
            if (_movementController.speed <= walkingRunningCutoff)
            {
                // make the waking animation slow down the slower the speed is
                speed = (_movementController.speed + .5f) / walkingRunningCutoff;
                speed = Math.Min(1, speed);

                state = 1;
            }
            else
            {
                //speed = 1;
                state = 2;
            }


            // reverse direction if walking backwards
            if (forwardSpeed < 0)
            {
                speed *= -1;
            }
        }

        animationController.SetFloat(_speedVarName, speed);
        animationController.SetInteger(_currentStateName, state);
    }
}