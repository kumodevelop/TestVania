using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    #region Others
    [Header("hitBox")]
    public GameObject hitBox;
    public bool test;
    private float dashStopTime;
    private string currentAttribute;

    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    //public DamageEffects.Effects currentBuff;
    
    //Other Scripts
    public PlayerInputHandler inputHandler { get; private set; }
    public GeneralData generalData { get; private set; }

    //Components
    private CapsuleCollider2D playerCollider;
    public Animator Anim { get; private set; }
    
    private Vector2 addDashForce;
    
    #endregion

    #region StateMachines
    public WarriorStateMachine StateMachine { get; private set; }
    public WarriorIdleState idleState { get; private set; }
    public WarriorWalkState walkState { get; private set; }
    public WarriorJumpState jumpState { get; private set; }
    public WarriorInAirState inAirState { get; private set; }
    public WarriorInCrouchState inCrouchState { get; private set; }
    public WarriorLandState landState { get; private set; }
    public WarriorDashState dashState { get; private set; }
    public WarriorAttackState attackState { get; private set; }
    public WarriorAttackState attackState2 { get; private set; }
    public WarriorAttackState attackState3 { get; private set; }       
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

    #region BasicFunctions
    private void Awake()
    {
        StateMachine = new WarriorStateMachine();

        idleState = new WarriorIdleState(this, StateMachine, "idle");
        walkState = new WarriorWalkState(this, StateMachine, "walk");
        jumpState = new WarriorJumpState(this, StateMachine, "inAir");
        inAirState = new WarriorInAirState(this, StateMachine, "inAir");
        landState = new WarriorLandState(this, StateMachine, "land");
        dashState = new WarriorDashState(this, StateMachine, "dash");
        inCrouchState = new WarriorInCrouchState(this, StateMachine, "crouch");
        attackState = new WarriorAttackState(this, StateMachine, "attack1");
        attackState2 = new WarriorAttackState(this, StateMachine, "attack2");
        attackState3 = new WarriorAttackState(this, StateMachine, "attack3");
        generalData = GetComponent<GeneralData>();
        generalData.currentBuff = DamageEffects.Effects.normal;
        facingDirection = 1;
                
    }

    private void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();       
        inputHandler = GetComponent<PlayerInputHandler>();
        StateMachine.Initialize(idleState);
        
    }

    public void ChangeCollider(Vector2 offsetnew,Vector2 sizenew)
    {
        playerCollider.offset = offsetnew;
        playerCollider.size = sizenew;
    }

    
    private void Update()
    {
        if(test)
        {
            generalData.currentBuff = DamageEffects.Effects.poison;
            Debug.Log("Your damage effect is " + generalData.currentBuff);

        }
        currentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region MechanicsFuncions
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
    
    public void SetDash()
    {
        addDashForce.Set(generalData.dashForce * facingDirection, 0);
        rb.velocity = addDashForce;
    }

    public void StopDash()
    {
        addDashForce.Set(0, 0);
        rb.velocity = addDashForce;
    }

    public void CheckFlip(int xinput)
    {
        if(xinput != 0 && xinput != facingDirection)
        {
            Turning();
        }
    }
    private void Turning()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180f, 0.0f);
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
    public void attackVelocity()
    {
        addDashForce.Set(0.2f * facingDirection, 0);
        rb.velocity = addDashForce;
    }

    public void ActivateHit()
    {
        if (hitBox.activeSelf)     
            hitBox.SetActive(false);
        
        hitBox.SetActive(true);
        StartCoroutine(EndHit());
        
    }

    IEnumerator EndHit()
    {
        yield return new WaitForSeconds(0.07f);
        hitBox.SetActive(false);
    }
    #endregion

}
