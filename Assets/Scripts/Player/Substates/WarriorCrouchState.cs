using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorCrouchState : WarriorAbilityState
{
    bool crouchInput;
    public WarriorCrouchState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityOn = true;
        player.SetVelocityX(0f);
        colliderOffset.Set(0, 0.76f);
        colliderSize.Set(0.73f, 1.46f);
        player.ChangeCollider(colliderOffset, colliderSize);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //crouchInput = player.inputHandler.crouchInput;
       // if(!crouchInput)
            //stateMachine.ChangeState(player.inCrouchState);


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
