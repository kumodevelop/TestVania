using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorJumpState : WarriorAbilityState
{
    public WarriorJumpState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(player.jumpspeed);
        isAbilityDone = true;
    }

}
