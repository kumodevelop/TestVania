using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorGroundedState : WarriorState
{
    protected int Xinput;
    protected int Yinput;
    public bool jumpInput;
    public bool dashInput;
    public bool attackInput;
    public bool canUseInput;
    public bool canAttack;
    private bool isGrounded;
    //Verificação para o Player parar de andar
    public bool isLand;
    public bool isCrouch;
    
    public WarriorGroundedState(WarriorController player, WarriorStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
       
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckGround();
    }

    public override void Enter()
    {
        base.Enter();
        player.jumpState.ResetJumps();
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
        dashInput = player.inputHandler.dashInput;
        attackInput = player.inputHandler.attackInput;
        canUseInput = player.inputHandler.canUseInput;

        if(jumpInput && player.jumpState.CanJump())
        {
            player.inputHandler.useJumpInput();
            stateMachine.ChangeState(player.jumpState);
        }
        else if(!isGrounded)
        {
            player.jumpState.DecreaseJumps();
            stateMachine.ChangeState(player.inAirState);
        }
        else if (isGrounded)
        {
            if (Yinput == -1)
            {
                isCrouch = true;
                stateMachine.ChangeState(player.inCrouchState);
            }
            else if (Yinput != -1)
            {
                isCrouch = false;
                if (attackInput)// && player.inputHandler.contAttacks<=3)
                {                    
                    //Debug.Log(player.attackState.ShowAttacksLeft());
                    stateMachine.ChangeState(player.attackState);
                }
                else if (!isLand)
                {
                    if (dashInput) //&& !attackInput)
                        stateMachine.ChangeState(player.dashState);
                }
            }
            

        }
        /* else if(dashInput && isGrounded && !isLand)
         {

         }
         if(isGrounded && Yinput ==-1)
         {
             isCrouch = true;
             stateMachine.ChangeState(player.inCrouchState);
         } 
         else
         {
             isCrouch = false;
         }*/
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
