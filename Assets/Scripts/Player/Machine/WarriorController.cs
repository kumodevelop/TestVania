using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour, IDamageable
{
    #region Others
    [Header("hitBox")]
    public GameObject hitBox;
    public bool test;
    private float dashStopTime;
    private string currentAttribute;

    [HideInInspector]
    public Rigidbody2D rb;
   // [HideInInspector]
    public bool isTakingDamage;
    public bool isInvincible;
    public float invincibleTime;
    public bool isDead;
    private Ghost ghostMode;

    [HideInInspector]
    public bool blink;
    private bool executeBlink;

    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D withFriction;
    //public DamageEffects.Effects currentBuff;
    
    //Other Scripts
    public PlayerInputHandler inputHandler { get; private set; }
    public GeneralData generalData { get; private set; }

    //Components
    private CapsuleCollider2D playerCollider;
    public Animator Anim { get; private set; }
    
    private Vector2 addDashForce;

    private SpriteRenderer spr;
    
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
    public WarriorGetHurtState getHurtState { get; private set; }
    public WarriorDeadState deadState { get; private set; }
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
        getHurtState = new WarriorGetHurtState(this, StateMachine, "hurt");
        deadState = new WarriorDeadState(this, StateMachine, "dead");
        generalData = GetComponent<GeneralData>();
        generalData.currentBuff = DamageEffects.Effects.normal;
        spr = GetComponent<SpriteRenderer>();
        ghostMode = GetComponent<Ghost>();
        facingDirection = 1;
        isDead = false;
        isTakingDamage = false;
        executeBlink = true;
                
    }

    private void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();       
        inputHandler = GetComponent<PlayerInputHandler>();
        StateMachine.Initialize(idleState);       
    }

    public void ActivateGhostMode()
    {
        ghostMode.activeGhost = true;
    }

    public void DeactivateGhostMode()
    {
        ghostMode.activeGhost = false;
    }

    public void ChangeCollider(Vector2 offsetnew,Vector2 sizenew)
    {
        playerCollider.offset = offsetnew;
        playerCollider.size = sizenew;
    }

    
    private void Update()
    {
        if(CheckGround())
        {            
            rb.sharedMaterial = withFriction;
        }
        else
        {
            rb.sharedMaterial = noFriction;
        }
        if(test)
        {
            generalData.currentBuff = DamageEffects.Effects.poison;
            Debug.Log("Your damage effect is " + generalData.currentBuff);

        }
        if (generalData.hp <= 0)
            isDead = true;
        //if (isInvincible)
          //  blink = true;

        if(blink)
        {
            if(executeBlink)
            StartCoroutine(BlinkTime());
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

    public void GetHitVelocity()
    {
        StopDash();
        Vector2 teste = new Vector2(-60f*facingDirection, 0);
        rb.AddForce(teste);
    }

    public void ActivateHit()
    {
        if (hitBox.activeSelf)     
            hitBox.SetActive(false);
        
        hitBox.SetActive(true);
        StartCoroutine(EndHit());       
    }    

    public void disableInvincible(float time,int ext)
    {
        StartCoroutine(timeDisableInvincible(time,ext));
    }

    public void Damage(float damaged)
    {
        if(!isTakingDamage && !isInvincible)
        {
            isTakingDamage = true;
            generalData.hp -= damaged;
        }
        
    }

    public void Destroying()
    {
    }
    #endregion

    #region Timers
    IEnumerator BlinkTime()
    {
        executeBlink = false;
        Color oldColor = spr.color;
        spr.color = new Color(255, 255, 255, 0);
        yield return new WaitForSeconds(0.1f);
        spr.color = oldColor;
        yield return new WaitForSeconds(0.1f);
        executeBlink = true;
    }

    IEnumerator timeDisableInvincible(float time,int isExiting)
    {
        isInvincible = true;
        yield return new WaitForSeconds(time);
        //0 - deactivate blink (used by getHurtState)
        //1 - Don't desactivate isInvincible if character was already invincible and blinking. (used by Dash State)
        if (isExiting == 0)
        {
            EndHurtTime();
        }
        else if(isExiting==1)
        {
            EndDashInvincibility();
        }       
    }

    private void EndHurtTime()
    {
        isInvincible = false;
        blink = false;
    }

    private void EndDashInvincibility()
    {
        if (!blink)
            isInvincible = false;
    }

    IEnumerator EndHit()
    {
        yield return new WaitForSeconds(0.07f);
        hitBox.SetActive(false);
    }

    #endregion

}
