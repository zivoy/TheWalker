using System;
using UnityEngine;

public class animator : MonoBehaviour
{
    public Animator animationController;
    private Charactermove _movementController;

    [Header("Speed thresholds")] public float walkingRunningCutoff = 3f;

    private readonly string _currentStateName = "Current State";
    private readonly string _speedVarName = "Speed";

    void Start()
    {
        _movementController = gameObject.GetComponent<Charactermove>();
    }

    void Update()
    {
        // movementController.PlayerMovementInput.x != 0  make rotation animation
        int state = 0;
        float speed = 1;
        if (_movementController.PlayerMovementInput.z != 0)
        {
            if (_movementController.Speed < walkingRunningCutoff)
            {
                // make the waking animation slow down the slower the speed is
                speed = (_movementController.Speed + .5f) / walkingRunningCutoff;
                speed = Math.Min(1, speed);

                state = 1;
            }
            else
            {
                //speed = 1;
                state = 2;
            }


            // reverse direction if walking backwards
            if (_movementController.PlayerMovementInput.z < 0)
            {
                speed *= -1;
            }
        }

        animationController.SetFloat(_speedVarName, speed);
        animationController.SetInteger(_currentStateName, state);
    }
}