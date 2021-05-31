using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorGroundedState : WarriorState
{
    protected int Xinput;
    protected int Yinput;
    public bool jumpInput;
    private bool isGrounded;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
