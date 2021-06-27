using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDashState : WarriorAbilityState
{
    private float startDashingTime;
    
    public WarriorDashState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isDashing = true;
        player.SetDash();
        startDashingTime = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        StopDashing();
    }
    private void StopDashing()
    {
        if(Time.time >= startDashingTime+player.generalData.dashingTime)
        {
            player.StopDash();
            isAbilityOn = true;
            stateMachine.ChangeState(player.landState);
        }
    }
}
