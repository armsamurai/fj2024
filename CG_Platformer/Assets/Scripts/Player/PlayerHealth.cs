using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    int hp;

    PlayerController controller;
    Rigidbody2D rb;
    HealthDisplay hpDisplay;

    bool immortal = false;
    void Start()
    {
        hp = maxHP;
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        hpDisplay = FindObjectOfType<HealthDisplay>();
        hpDisplay.SetupHealth(maxHP);
    }

    
    public void GetDamage(Vector3 vel)
    {
        if (immortal) return;
        if (controller.state == PlayerState.DEAD) return;

        hp--;
        hpDisplay.Display(hp);
        rb.velocity = vel;
        if (hp <= 0) StartCoroutine(Death());
        else StartCoroutine(DisabledCoroutine());
    }

    IEnumerator DisabledCoroutine()
    {
        controller.state = PlayerState.DISABLED;
        immortal = true;
        yield return new WaitForSeconds(0.1f);
        controller.state = PlayerState.FALL;
        yield return new WaitForSeconds(0.25f);
        immortal = false;
    }

    IEnumerator Death()
    {
        controller.state = PlayerState.DEAD;
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetInteger("state", 10);
        GetComponent<Rigidbody2D>().velocity = new Vector2();
    }

    public void Heal(int addHP)
    {
        hp += addHP;
        if (hp >= maxHP)
        {
            hp = maxHP;
        }
        hpDisplay.Display(hp);
    }
}
