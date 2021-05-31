using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    #region Others
    [Header("Variables")]
    public float speed;
    public float jumpspeed;
    [HideInInspector]
    public Rigidbody2D rb;
    public PlayerInputHandler inputHandler { get; private set; }
    public Animator Anim { get; private set; }
    #endregion

    #region StateMachines
    public WarriorStateMachine StateMachine { get; private set; }
    public WarriorIdleState idleState { get; private set; }
    public WarriorWalkState walkState { get; private set; }

    public WarriorJumpState jumpState { get; private set; }

    public WarriorInAirState inAirState { get; private set; }
    public WarriorLandState landState { get; private set; }

    #endregion

    #region WalkVariables
    private Vector2 workspace;
    public Vector2 currentVelocity { get; private set; }
    
    [HideInInspector]
    public int facingDirection { get; private set; }
    #endregion

    #region JumpVariables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask isGroundLayer;
    public int jumpqnt;
    public float jumpHighMultiplier;
    #endregion   

    #region Functions
    private void Awake()
    {
        StateMachine = new WarriorStateMachine();

        idleState = new WarriorIdleState(this, StateMachine, "idle");
        walkState = new WarriorWalkState(this, StateMachine, "walk");
        jumpState = new WarriorJumpState(this, StateMachine, "inAir");
        inAirState = new WarriorInAirState(this, StateMachine, "inAir");
        landState = new WarriorLandState(this, StateMachine, "land");
        facingDirection = 1;
        
    }

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();       
        inputHandler = GetComponent<PlayerInputHandler>();
        StateMachine.Initialize(idleState);
    }

    private void Update()
    {
        currentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, currentVelocity.y);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set (currentVelocity.x, velocity);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    private void Turning()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180f, 0.0f);
    }

    public void CheckFlip(int xinput)
    {
        if(xinput != 0 && xinput != facingDirection)
        {
            Turning();
        }
    }

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,isGroundLayer);
    }
    
    private void AnimationTrigger()
    {
        StateMachine.CurrentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    #endregion


}
