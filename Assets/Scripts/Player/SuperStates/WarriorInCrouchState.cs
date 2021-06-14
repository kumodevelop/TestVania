using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorInCrouchState : WarriorState
{
    private bool isGrounded;
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Yinput = player.inputHandler.normalizeInputY;
        if (isGrounded && Yinput != -1)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
