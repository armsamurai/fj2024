using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int addHP = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D & collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Heal(addHP);
            Destroy(gameObject);
            
        }
    }
}
