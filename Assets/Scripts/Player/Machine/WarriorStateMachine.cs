using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorStateMachine
{
    public WarriorState CurrentState { get; private set; }

    public void Initialize(WarriorState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(WarriorState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
