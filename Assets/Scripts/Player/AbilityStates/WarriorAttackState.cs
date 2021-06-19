using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackState : WarriorAbilityState
{
    private float startAttackTime;
    private float attackTime = 0.5f;
    public WarriorAttackState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
        startAttackTime = Time.time;      
    }

    public override void Exit()
    {

        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //Debug.Log("Chão = " + player.CheckGround().ToString());
        StopAttack();
    }

    public void StopAttack()
    {
        if (Time.time >= startAttackTime + attackTime)       
            isAbilityOn = true;
                    
    }
}
