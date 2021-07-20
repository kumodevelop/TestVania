using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDeadState : WarriorDamageState
{
    public WarriorDeadState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.blink = false;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
