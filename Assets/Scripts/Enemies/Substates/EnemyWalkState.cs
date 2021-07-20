using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyGroundedState
{
    public EnemyWalkState(EnemyController enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
}
