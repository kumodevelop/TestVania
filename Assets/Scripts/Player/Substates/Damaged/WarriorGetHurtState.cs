using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorGetHurtState : WarriorDamageState
{
    private float startHurtTime;
    public WarriorGetHurtState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.disableInvincible(2f,0);
        player.blink = true;
        startHurtTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        isHurt = true;
        player.StopDash();
        player.GetHitVelocity();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.StopDash();
        player.GetHitVelocity();
        StopHurting();

    }

    private void StopHurting()
    {
        if (Time.time >= startHurtTime + 0.4f)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
