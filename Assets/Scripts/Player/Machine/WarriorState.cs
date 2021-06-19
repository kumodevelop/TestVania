using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorState
{
    protected WarriorController player;
    protected WarriorStateMachine stateMachine;

    public Vector2 colliderOffset;
    public Vector2 colliderSize;

    protected float startTime;

    private string animBoolName;

    protected bool isAnimationFinish = false;

    public WarriorState(WarriorController player, WarriorStateMachine stateMachine,string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        player.Anim.SetBool(animBoolName, true);
        //Debug.Log(animBoolName);
        isAnimationFinish = false;       
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
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
