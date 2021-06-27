using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackState : WarriorAbilityState
{
    private float startAttackTime;
    private float canAttackTime = 0.3f;
    private float attackTime = 0.6f;
    public WarriorAttackState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(player.inputHandler.attackInput && animBoolName=="attack3")
        {
            player.StopDash();
        }
        startAttackTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CanAttack();
        StopAttack(); 
    }

    public void CanAttack()
    {
        if (Time.time >= startAttackTime + canAttackTime)
        {

            if (player.inputHandler.attackInput && isGrounded)
            {
                if (animBoolName == "attack1")
                {
                    stateMachine.ChangeState(player.attackState2);
                    isAbilityOn = true;
                }
                else if (animBoolName == "attack2")
                {
                    stateMachine.ChangeState(player.attackState3);
                }
            }           
        }
    }

    public void StopAttack()
    {
        if (Time.time >= startAttackTime + attackTime)
        {           
                isAbilityOn = true;
        }
    }
}
