using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ooze : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
    }

    
    void Update()
    {
        bool isWall = CheckWall();
        bool isGround = CheckGround();

        if (isWall || !isGround)
        {
            transform.Rotate(0, 180, 0);
            rb.velocity = -transform.right * speed;
        }
    }

    bool CheckWall()
    {
        Vector2 origin = transform.position;
        Vector2 direction = -transform.right;
        float distance = 0.5f;
        LayerMask layer = LayerMask.GetMask("Ground", "Hazards");

        bool isHit = Physics2D.Raycast(origin, direction, distance, layer);
        return isHit;
    }

    bool CheckGround()
    {
        Vector2 origin = transform.position;
        Vector2 direction = -transform.right - transform.up;
        float distance = 0.8f;
        LayerMask layer = LayerMask.GetMask("Ground");

        bool isHit = Physics2D.Raycast(origin, direction, distance, layer);
        return isHit;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player)
        {
            Vector3 vel = new Vector3(-10, 15);
            if (player.transform.position.x > transform.position.x) vel = new Vector3(10, 15);

            player.GetDamage(vel);
        }
    }
}
