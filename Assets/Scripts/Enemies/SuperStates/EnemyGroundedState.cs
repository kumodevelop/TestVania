using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundedState : EnemyState
{
    private bool isGrounded;
    public EnemyGroundedState(EnemyController enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(enemy.canWalk && enemy.isWalking)
        {
            stateMachine.ChangeState(enemy.walkState);
        }
        if(enemy.isNotMoving)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
