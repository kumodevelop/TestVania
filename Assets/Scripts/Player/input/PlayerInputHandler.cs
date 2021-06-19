using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    #region Input Variables
    public Vector2 RawMovementInput { get; private set; }
    public int normalizeInputX { get; private set; }
    public int normalizeInputY { get; private set; }
    public bool jumpInput { get; private set; }

    public bool crouchInput { get; private set; }

    public bool dashInput { get; private set; }

    public bool attackInput { get; private set; }

    public bool jumpInputStop { get; private set; }

    public bool dashInputStop { get; private set; }

    public bool attackInputStop { get; private set; }

    
    #endregion

    #region Hold Time Variables

    public float inputHoldTime;
    
    private float jumpInputStartTime;

    public float inputDashTime;

    private float dashInputStartTime;

    public float inputAttackTime;

    private float attackInputStartTime;

    #endregion

    private void Update()
    {
        CheckInputTime();

        CheckDashTime();

        CheckCrouch();

        CheckAttackTime();
    }

    public void useJumpInput()
    {
        jumpInput = false;
    }

    #region Check Functions
    private void CheckInputTime()
    {
        if(Time.time >= jumpInputStartTime+inputHoldTime)
        {
            jumpInput = false;
        }        
    }

    private void CheckDashTime()
    {
        if (Time.time >= dashInputStartTime + inputDashTime)
        {
            dashInput = false;
            
        }
    }

    public void CheckCrouch()
    {
        if (normalizeInputY == -1)
        {
            crouchInput = true;
        }
        else
        {
            crouchInput = false;
        }
    }

    private void CheckAttackTime()
    {
        if (Time.time >= attackInputStartTime + inputAttackTime)
        {
            attackInput = false;
        }
    }
    #endregion

    #region Input Functions
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        if (Mathf.Abs(RawMovementInput.x) > 0.5f)
        {
            normalizeInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
            
        }
        else
        {
            normalizeInputX = 0;
        }

        if (Mathf.Abs(RawMovementInput.y) > 0.5f)
        {
            normalizeInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        }
        else
        {
            normalizeInputY = 0;
        }       
            
    }
    

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            jumpInput = true;
            jumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            jumpInputStop = true;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            dashInput = true;
            //dashInputStop = false;
            dashInputStartTime = Time.time;
            CheckAttackTime();
        }
        if (context.canceled)
        {
            //dashInputStop = true;
        }

    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attackInput = true;
            //attackInputStop = false;
            attackInputStartTime = Time.time;
        }           
        if (context.canceled)
        {
            attackInput = false;
        }
           // attackInput = false;
    }
    #endregion

    


}
