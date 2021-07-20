using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDamageState : WarriorState
{
    protected bool isHurt;
    protected bool isGrounded;
    public WarriorDamageState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        isHurt = false;
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.isDead)
        {
            stateMachine.ChangeState(player.deadState);
        }
        else if (isHurt)
        {
            if (isGrounded && player.currentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else if (!isGrounded)
            {
                stateMachine.ChangeState(player.inAirState);
            }
        }
    }    
}
