using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorInCrouchState : WarriorState
{
    private bool isGrounded;
    protected int Xinput;
    protected int Yinput;
    public WarriorInCrouchState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        player.SetVelocityX(0f);
        colliderOffset.Set(0, 0.84f);
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
        Xinput = player.inputHandler.normalizeInputX;
        Yinput = player.inputHandler.normalizeInputY;
        player.CheckFlip(Xinput);
        if (Yinput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
