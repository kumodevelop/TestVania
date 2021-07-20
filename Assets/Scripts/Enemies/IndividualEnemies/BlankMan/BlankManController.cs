using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankManController : EnemyController
{
    public GeneralData generalData { get; private set; }
    [HideInInspector] public int facingDirection { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        StateMachine.Initialize(idleState);
    }

    private void Awake()
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

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();

        if (playerObject.transform.position.x < transform.position.x && facingDirection == 1 && isNotMoving)
        {
            Turning();
        }
        else if (playerObject.transform.position.x > transform.position.x && facingDirection == -1 && isNotMoving)
        {
            Turning();
        }
    }

    private void FixedUpdate()
    {
        if (CheckGround() && rb.velocity == Vector2.zero)
        {
            isNotMoving = true;
//            isWalking = false;
        }
        else
        {
            isNotMoving = false;
        }

        if (PlayerDistance() < 3f)
        {
            Debug.Log("Sugee Chikai");
            rb.AddForce(new Vector2(facingDirection * -0.2f, 0.2f),ForceMode2D.Impulse);
            
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        StateMachine.CurrentState.PhysicsUpdate();        
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
