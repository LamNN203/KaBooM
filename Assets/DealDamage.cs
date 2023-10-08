using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public Collider2D col;
    public EnemyBehavior enemy;
    public int damage;

    void Start()
    {
        col = GetComponent<Collider2D>();
        enemy = FindObjectOfType<EnemyBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy.TakeHit(damage);
        }
    }
}
