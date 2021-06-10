using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAbilityState : WarriorState
{

    protected bool isAbilityDone;
    protected bool isGrounded;
    protected bool isDashing = false;
    public WarriorAbilityState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        player.CheckGround();
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAbilityDone)
        {
            if(isGrounded && player.currentVelocity.y < 0.01f && !isDashing)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else if(!isGrounded && !isDashing)
            {
                stateMachine.ChangeState(player.inAirState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
