using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyController enemy;
    protected EnemyStateMachine stateMachine;

    public Vector2 colliderOffset;
    public Vector2  colliderSize;

    protected float startTime;
    public string animBoolName;
    protected bool isAnimationFinish = false;

    public EnemyState(EnemyController enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        enemy.Anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishTrigger()
    {
        isAnimationFinish = true;
    }


}
