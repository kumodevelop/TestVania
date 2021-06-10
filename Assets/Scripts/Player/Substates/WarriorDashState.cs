using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDashState : WarriorAbilityState
{
    private float startDashingTime;

    public WarriorDashState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Cheguei no State");
        isAbilityDone = true;
        isDashing = true;
        player.SetVelocityX(0f);
        player.SetDash();
        startDashingTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        StopDashing();


    }
    private void StopDashing()
    {
        if(Time.time >= startDashingTime+player.dashingTime)
        {
            player.StopDash();
            stateMachine.ChangeState(player.landState);
        }
    }
}
