using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorJumpState : WarriorAbilityState
{
    private int jumpsleft;
    public WarriorJumpState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        jumpsleft = player.jumpqnt;
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(player.jumpspeed);
        isAbilityOn = true;
        jumpsleft--;
        player.inAirState.setIsJumping();
    }

    public bool CanJump()
    {
        if(jumpsleft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetJumps()
    {
        jumpsleft = player.jumpqnt;
    }

    public void DecreaseJumps()
    {
        jumpsleft--;
    }

}
