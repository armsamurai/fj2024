using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
        FlipCharacter();
    }


    void Move()
    {
        float newX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(newX, rb.velocity.y);
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
