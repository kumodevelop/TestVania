using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAbilityState : WarriorState
{

    protected bool isAbilityOn;
    protected bool isGrounded;
    public WarriorAbilityState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        isAbilityOn = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();        
        if(isAbilityOn)
        {
            if(isGrounded && player.currentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else if(!isGrounded)
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
