using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrapScp : MonoBehaviour
{

    public controller Player;
    public Animator anim;
    public Rigidbody2D rg;
    public Rigidbody2D Ball;
    public Collider2D Col;
    public GameObject FireEffect;
    public GameObject Part1;
    public GameObject Part2;
    public GameObject Part3;

    public enum State { idle, Shotting, hitted }
    public State state = State.idle;
    public bool CanShoot = false;
    public float ShootRate;
    public float timer = 0;
    public float ShootForceX;
    public float ShootForceY;
    public float HP;
    public int hurtforce = 0;



    public void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        Player = FindObjectOfType<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("state", (int)state);

        if (state != State.hitted )
        {
            if (timer < ShootRate)
            {
                timer = timer + Time.deltaTime;
            }
            else if (timer > ShootRate && CanShoot == true)
            {
                Startshooting();
                timer = 0;
            }
        }
    }

    public void Startshooting() 
    {
        if (state != State.hitted)
        {
            state = State.Shotting;
        }
    }
    public void shooting()
    {
        if (state != State.hitted)
        {
            Rigidbody2D Clone;
            Clone = Instantiate(Ball, new Vector2(transform.position.x - 0.8f, transform.position.y), transform.rotation);
            Clone.velocity = new Vector2(ShootForceX, ShootForceY);
            Instantiate(FireEffect, new Vector2(transform.position.x - 0.8f, transform.position.y), transform.rotation);
        }
    }
    public void BackToIdle()
    {
        state = State.idle;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerHitBox")
        {
            state = State.hitted;
            TakeHit(1);
        }
    }

    public void Died()
    {
        Destroy(this.gameObject);
        Instantiate(Part1, transform.position, transform.rotation);
        Instantiate(Part2, transform.position, transform.rotation);
        Instantiate(Part3, transform.position, transform.rotation);
    }
    public void TakeHit(int damage)
    {
        HP -= damage; // Tru mau
        // healthctr.SetHealth(hitpoints, Maxhitpoins);
        Knockback();
        if (HP <= 0)
        {
            OnDeath();
        }
    }
    public void Knockback()
    {
        if (Player.gameObject.transform.position.x > transform.position.x)
        {
            rg.velocity = new Vector2(-hurtforce, hurtforce - 1);
        }
        if (Player.gameObject.transform.position.x < transform.position.x)
        {
            rg.velocity = new Vector2(hurtforce, hurtforce - 1);
        }
    }

    public void OnDeath()
    {
        anim.SetBool("IsDeath", true);
        Debug.Log("death");
    }

}
