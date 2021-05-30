using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int normalizeInputX { get; private set; }
    public int normalizeInputY { get; private set; }
    public bool jumpInput { get; private set; }

    public float inputHoldTime;

    public float jumpInputStartTime;

    private void Update()
    {
        CheckInputTime();
    }

    private void CheckInputTime()
    {
        if(Time.time >= jumpInputStartTime+inputHoldTime)
        {
            jumpInput = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        //Debug.Log("Andando!");

        normalizeInputX =(int)(RawMovementInput * Vector2.right).normalized.x;
        normalizeInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {

        if(context.started)
        {
            jumpInput = true;
            jumpInputStartTime = Time.time;
        }
    }
    public void useJumpInput()
    {
        jumpInput = false;
    }


}
