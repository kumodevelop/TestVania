using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorInAirState : WarriorState
{
    private int xInput;
    private bool isGround;
    
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
        xInput = player.inputHandler.normalizeInputX;
        base.LogicUpdate();
        if(isGround && player.currentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.landState);
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
}
