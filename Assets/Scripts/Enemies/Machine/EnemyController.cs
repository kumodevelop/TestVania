using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool canWalk;
    public bool canDash;
    public bool isWalking;
    public bool isDashing;
    public bool isNotMoving;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask isGroundLayer;


    [HideInInspector] public GameObject playerObject;
    [HideInInspector] public Animator Anim;
    [HideInInspector] public Rigidbody2D rb;
    public EnemyIdleState idleState;
    public EnemyWalkState walkState;
    public EnemyStateMachine StateMachine;

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
    }


}
