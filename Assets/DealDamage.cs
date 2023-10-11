using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public Collider2D col;
    public EnemyBehavior enemy;
    public BarrelScrip Barrel;
    public int damage;

    void Start()
    {
        col = GetComponent<Collider2D>();
        enemy = FindObjectOfType<EnemyBehavior>();
        Barrel = FindObjectOfType <BarrelScrip>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy.TakeHit(damage);
        }

        if (other.gameObject.tag == "Barrel")
        {
            Barrel.TakeHit(damage);
        }
    }
}
