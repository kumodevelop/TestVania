using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackState : WarriorAbilityState
{
    private float startAttackTime;
    private float canAttackTime = 0.3f;
    private float attackTime = 0.6f;
    private int entrei = 0;
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
        if(player.inputHandler.attackInput && animBoolName=="attack1")
        {
           // Debug.Log("Oi");
        }
        //Debug.Log("Entrei "+entrei+ "vezes");
        
        //player.inputHandler.countAttack++;
        /*
        if(player.attacksleft==2)
        {
            player.Anim.SetBool("attack1", false);
            player.Anim.SetBool("attack2", true);
            animBoolName = "attack2";
        }
        if(player.attacksleft ==1 || player.attacksleft == 3)
        {
            player.Anim.SetBool("attack2", false);
            player.Anim.SetBool("attack1", true);
            animBoolName = "attack1";
        }
        player.attacksleft--;
        player.SetVelocityX(0f);
           */
        startAttackTime = Time.time;
    }

    public override void Exit()
    {
        //player.Anim.SetBool("attack1", false);
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //Debug.Log("Chão = " + player.CheckGround().ToString());
        CanAttack();
        StopAttack(); 
    }

    /*public bool canAttack()
    {
        if (player.attacksleft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int ShowAttacksLeft()
    {
        return player.attacksleft;
    }*/
    public void CanAttack()
    {
        if (Time.time >= startAttackTime + canAttackTime)
        {
            if (player.inputHandler.attackInput && animBoolName == "attack1")
            {
                stateMachine.ChangeState(player.attackState2);
                isAbilityOn = true;
            }
            else if(player.inputHandler.attackInput && animBoolName == "attack2")
            {
                stateMachine.ChangeState(player.attackState3);
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
