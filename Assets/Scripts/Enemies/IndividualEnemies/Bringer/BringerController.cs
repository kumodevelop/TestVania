using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerController : EnemyController
{
    public GeneralData generalData { get; private set; }
    [HideInInspector] public int facingDirection { get; private set; }

    void Awake()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        generalData = GetComponent<GeneralData>();
        generalData.currentBuff = DamageEffects.Effects.normal;
        StateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState(this, StateMachine, "idle");
        playerObject = GameObject.Find("Player");
        facingDirection = 1;
    }
    void Start()
    {
        StateMachine.Initialize(idleState);
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (CheckGround() && rb.velocity == Vector2.zero)
        {            
            isNotMoving = true;
            Debug.Log("Distancia = "+PlayerDistance());
        }
        if (PlayerDistance() > 2f)
        {
            rb.velocity = new Vector2(facingDirection*2f, rb.velocity.y);
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
