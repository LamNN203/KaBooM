using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private int hitpoints;
    public int Maxhitpoins = 3;
    public int hurtforce = 0;
    //public HealthBar healthctr;
    protected Animator anim;
    protected Rigidbody2D rg;
    public Enemy a;
    public int Score;
    public controller Player;


    private void Start()
    {
        hitpoints = Maxhitpoins;
       // healthctr.SetHealth(hitpoints, Maxhitpoins);
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        a = FindObjectOfType<Enemy>();
        Player = FindObjectOfType<controller>();
    }

    public void TakeHit(int damage)
    {
        hitpoints -= damage; // Tru mau
        // healthctr.SetHealth(hitpoints, Maxhitpoins);
        Knockback();
        if (hitpoints <= 0)
        {
            a.OnDeath();
        }
    }

    public void Knockback()
    {
        if (Player.gameObject.transform.position.x > transform.position.x)
        {
            rg.velocity = new Vector2(-hurtforce, hurtforce - 1 );
        }
        if (Player.gameObject.transform.position.x < transform.position.x)
        {
            rg.velocity = new Vector2(hurtforce, hurtforce - 1 );
        }
    }

}
