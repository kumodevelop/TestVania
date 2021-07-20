using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkeletonController : EnemyController
{
    public GeneralData generalData { get; private set; }
    [HideInInspector] public int facingDirection { get; private set; }

    // Start is called before the first frame update
    void Start()
    {       
        StateMachine.Initialize(idleState);
        
    }

    private void FixedUpdate()
    {
        if (CheckGround() && rb.velocity == Vector2.zero)
        {
            isNotMoving = true;
            isWalking = false;
        }
        else
        {
            isNotMoving = false;
        }
        if (PlayerDistance() > 2f && canWalk)
        {
            rb.velocity = new Vector2(facingDirection * 2f, rb.velocity.y);
            isWalking = true;
            if (playerObject.transform.position.x < transform.position.x && facingDirection == 1)
            {
                Turning();
            }
            else if (playerObject.transform.position.x > transform.position.x && facingDirection == -1)
            {
                Turning();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        StateMachine.CurrentState.PhysicsUpdate();
    }

    

    void Awake()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        generalData = GetComponent<GeneralData>();
        generalData.currentBuff = DamageEffects.Effects.normal;
        StateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState(this, StateMachine, "idle");
        walkState = new EnemyWalkState(this, StateMachine, "walk");
        playerObject = GameObject.Find("Player");
        facingDirection = 1;
    }

    void Update()
    { 
        StateMachine.CurrentState.LogicUpdate();
    }
    private void Turning()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180f, 0.0f);
    }

    private float PlayerDistance()
    {
        return Vector2.Distance(playerObject.transform.position, transform.position);
    }


}
