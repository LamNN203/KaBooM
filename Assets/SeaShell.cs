using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaShell : MonoBehaviour
{
    public controller Player;
    public Animator anim;
    public Rigidbody2D rg;
    public Rigidbody2D Ball;
    public Collider2D Col;
    public Transform player;
    public GameObject FireEffect;
    public GameObject HittedEffect;
    public GameObject Part1;
    public GameObject Part2;
    public GameObject Part3;
    public GameObject Part4;

    public enum State { idle, Shotting, hitted, bitting }
    public State state = State.idle;
    public bool CanShoot = false;
    public bool CanBite = false;
    public float ShootRate;
    public float BiteRate;
    public float timer = 0;
    public float ShootTimer = 0;
    public float ShootForceX;
    public float ShootForceY;
    public float BiteForceX;
    public float BiteForceY;
    public int HP;
    public int hurtforce = 0;



    public void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        Player = FindObjectOfType<controller>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("state", (int)state);

        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }


        if (state != State.hitted)
        {
            if (timer < ShootRate)
            {
                timer = timer + Time.deltaTime;
            }
            else if (timer > ShootRate && CanShoot == true && CanBite == false)
            {
                Startshooting();
                timer = 0;
            }

            if (ShootTimer < BiteRate)
            {
                ShootTimer = ShootTimer + Time.deltaTime;
            }
            else if (ShootTimer > ShootRate && CanBite == true)
            {
                Biting();
                ShootTimer = 0;
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

    public void Biting()
    {
        if (player.transform.position.x < transform.position.x)
        {
            rg.velocity = new Vector2(-BiteForceX, BiteForceY);
            state = State.bitting;
            CanBite = false;
            timer = 0;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            rg.velocity = new Vector2(BiteForceX, BiteForceY);
            state = State.bitting;
            CanBite = false;
            timer = 0;
        }
    }

    public void shooting()
    {
        if (state != State.hitted)
        {
            if (player.transform.position.x < transform.position.x)
            {
                Rigidbody2D Clone;
                Clone = Instantiate(Ball, new Vector2(transform.position.x - 0.8f, transform.position.y - 0.32f), transform.rotation);
                Clone.velocity = new Vector2(-ShootForceX, ShootForceY);
                Instantiate(FireEffect, new Vector2(transform.position.x - 0.8f, transform.position.y - 0.32f), transform.rotation);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                Rigidbody2D Clone;
                Clone = Instantiate(Ball, new Vector2(transform.position.x + 0.8f, transform.position.y - 0.32f), transform.rotation);
                Clone.velocity = new Vector2(ShootForceX, ShootForceY);
                Instantiate(FireEffect, new Vector2(transform.position.x + 0.8f, transform.position.y - 0.32f), transform.rotation);
            }
        }
    }
    public void BackToIdle()
    {
        state = State.idle;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            state = State.hitted;
            TakeHit(1);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            TakeHit(1);
        }
    }

    public void Died()
    {
        Destroy(this.gameObject);
        Instantiate(Part1, transform.position, transform.rotation);
        Instantiate(Part2, transform.position, transform.rotation);
        Instantiate(Part3, transform.position, transform.rotation);
        Instantiate(Part4, transform.position, transform.rotation);
    }
    public void TakeHit(int damage)
    {
        HP -= damage; // Tru mau
        // healthctr.SetHealth(hitpoints, Maxhitpoins);
        Knockback();
        Instantiate(HittedEffect, transform.position, transform.rotation);
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
