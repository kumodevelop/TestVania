using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorIdleState : WarriorGroundedState
{

    public WarriorIdleState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        
        base.LogicUpdate();
        player.CheckFlip(Xinput);
        if(Xinput != 0)
        {
            stateMachine.ChangeState(player.walkState);            
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
