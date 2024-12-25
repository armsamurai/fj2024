using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSystem : MonoBehaviour
{
    [SerializeField] float duration = 5f;

    [SerializeField] float bSpeed = 10f;
    float speed;

    [SerializeField] float bJump = 40f;
    float jump;

    PlayerController controller;

    void Start()
    {
        controller = GetComponentInParent<PlayerController>();
        speed = controller.GetSpeed();
        jump = controller.GetJumpForce();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            StartCoroutine(SpeedBoost());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("JumpBoost"))
        {
            StartCoroutine(JumpBoost());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator SpeedBoost()
    {
        controller.SetSpeed(bSpeed);
        yield return new WaitForSeconds(duration);
        controller.SetSpeed(speed);
    }

    IEnumerator JumpBoost()
    {
        controller.SetJumpForce(bJump);
        yield return new WaitForSeconds(duration);
        controller.SetJumpForce(jump);
    }
}
