using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorLandState : WarriorGroundedState
{
    public WarriorLandState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
        isLand = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (isAnimationFinish)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    
}
