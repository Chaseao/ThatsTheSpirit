using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum State
    {
        Walking
        //Damage???
    }


    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        movementSpeed;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    private int facingDirection;

    private bool
       groundDetected,
       wallDetected;

    private Vector2 movement;

    private GameObject render;
    private Rigidbody2D renderRb;
    //private GameObject renderFlip;

    private State currentState;

    private void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;

                // this is left for potential future
        }
    }

    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Walking:
                //exit
                break;
        }

        switch (state)
        {
            case State.Walking:
                //enter
                break;
        }

        currentState = state;
    }
    private void Flip()
    {
        facingDirection *= -1;
        renderRb.transform.Rotate(0.0f, 180.0f, 0.0f);


    }

    private void Start()
    {
        render = transform.Find("Render").gameObject;
        renderRb = render.GetComponent<Rigidbody2D>();
       // renderFlip = transform.Find("RenderFlip").gameObject;

        facingDirection = 1;
    }

    private void UpdateWalkingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        //wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if (!groundDetected)
        {
            Flip();
            Debug.Log("flip");


        }
        else
        {
            movement.Set(movementSpeed * facingDirection, renderRb.velocity.y);
            renderRb.velocity = movement;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            Flip();
        }
    }








}
