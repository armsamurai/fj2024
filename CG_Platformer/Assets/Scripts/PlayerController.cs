using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    IDLE, 
    WALK, 
    FALL, 
    CLIMB,
    ATTACK,
    DISABLED,
    DEAD
}


public class PlayerController : MonoBehaviour
{
    public PlayerState state = PlayerState.IDLE;

    Rigidbody2D rb;
    CircleCollider2D legs;
    Animator anim;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        legs = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
        Jump();
        FlipCharacter();


        SetAnim();
    }

    void SetAnim()
    {
        if (state == PlayerState.IDLE) anim.SetInteger("state", 0);
        else if (state == PlayerState.WALK) anim.SetInteger("state", 1);
        else if (state == PlayerState.FALL) anim.SetInteger("state", 2);
        else if (state == PlayerState.CLIMB) anim.SetInteger("state", 3);
    }


    void Move()
    {
        float newX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(newX, rb.velocity.y);

        float velX = Mathf.Abs(rb.velocity.x);
        if (velX > 0.5f) state = PlayerState.WALK;
        else state = PlayerState.IDLE;
    }


    void Jump()
    {
        LayerMask ground = LayerMask.GetMask("Ground");
        bool isGrounded = legs.IsTouchingLayers(ground);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else
        {
            state = PlayerState.FALL;
        }
    }


    void FlipCharacter()
    {
        if(rb.velocity.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (rb.velocity.x < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
