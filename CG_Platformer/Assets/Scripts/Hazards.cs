using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    [SerializeField] float push = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            Vector3 vel = new Vector3(0, push);
            playerHealth.GetDamage(vel);
        }
    }
}
