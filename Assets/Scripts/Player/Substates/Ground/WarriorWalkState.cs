using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorWalkState : WarriorGroundedState
{
    public WarriorWalkState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!dashInput && !isCrouch &&!attackInput)
         player.SetVelocityX(player.generalData.speed * Xinput);
        
        if(Xinput==0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
