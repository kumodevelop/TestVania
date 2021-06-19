using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorInAirState : WarriorState
{
    private int xInput;
    private bool isGround;
    private bool jumpInput;
    private bool isJumping;
    private bool jumpInputStop;
    
    public WarriorInAirState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGround = player.CheckGround();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }  

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.inputHandler.normalizeInputX;
        jumpInput = player.inputHandler.jumpInput;
        jumpInputStop = player.inputHandler.jumpInputStop;
        CheckJumpMultiplier();
        if(isGround && player.currentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.landState);
        }
        else if(jumpInput && player.jumpState.CanJump())
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else
        {
            player.CheckFlip(xInput);
            player.SetVelocityX(player.speed * xInput);

            player.Anim.SetFloat("yVelocity", player.currentVelocity.y);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                isJumping = false;
                player.SetVelocityY(player.currentVelocity.y * player.jumpHighMultiplier);
            }
            else if (player.currentVelocity.y <= 0)
            {
                isJumping = false;
            }
        }
    }

    public void setIsJumping()
    {
        isJumping = true;
    }
}
