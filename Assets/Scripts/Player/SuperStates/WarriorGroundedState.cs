using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorGroundedState : WarriorState
{
    protected int Xinput;
    protected int Yinput;
    public bool jumpInput;
    private bool isGrounded;
    public bool dashInput;
    public bool isLand;
    public bool isCrouch;
    public WarriorGroundedState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckGround();
    }

    public override void Enter()
    {
        base.Enter();
        player.jumpState.ResetJumps();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Xinput = player.inputHandler.normalizeInputX;
        Yinput = player.inputHandler.normalizeInputY;
        jumpInput = player.inputHandler.jumpInput;
        dashInput = player.inputHandler.dashInput;

        if(jumpInput && player.jumpState.CanJump())
        {
            player.inputHandler.useJumpInput();
            stateMachine.ChangeState(player.jumpState);
        }
        else if(!isGrounded)
        {
            player.jumpState.DecreaseJumps();
            stateMachine.ChangeState(player.inAirState);
        }
        else if(dashInput && isGrounded && !isLand)
        {
            stateMachine.ChangeState(player.dashState);
        }
        if(isGrounded && Yinput ==-1 && !isLand)
        {
            stateMachine.ChangeState(player.inCrouchState);
        }       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
