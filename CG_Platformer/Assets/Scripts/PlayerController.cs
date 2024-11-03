using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D legs;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        legs = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        Move();
        Jump();
        FlipCharacter();
    }


    void Move()
    {
        float newX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(newX, rb.velocity.y);
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
