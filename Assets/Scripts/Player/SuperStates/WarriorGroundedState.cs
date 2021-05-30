using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorGroundedState : WarriorState
{
    protected int Xinput;
    protected int Yinput;
    public bool jumpInput;  
    public WarriorGroundedState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
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
        Xinput = player.inputHandler.normalizeInputX;
        Yinput = player.inputHandler.normalizeInputY;
        jumpInput = player.inputHandler.jumpInput;

        if(jumpInput)
        {
            player.inputHandler.useJumpInput();
            stateMachine.ChangeState(player.jumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
