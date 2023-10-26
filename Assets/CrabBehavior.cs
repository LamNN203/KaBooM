using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBehavior : MonoBehaviour
{
    // anim
    public enum State { idle, run,charge, attack, }

    // frog move
    public int HP;
    public float hurtforce = 0;
    public float RunForce;
    public float timer;
    public float timer2;
    public float Delaymove;
    public bool CanAction = true;
    public float Distance;
    public State state = State.idle;
    public LayerMask ground;
    public bool Facingleft = true;
    public bool IsDead = false;
    
    public float OriginPoint;

    public controller Player;
    public Animator anim;
    public Rigidbody2D rg;
    public Collider2D coll;
    public Transform player;
    public Transform me;
    public GameObject HitBox;
    public GameObject Reward;
    public RadaForCrab Rada;
    public SlowMotion Slow;

     void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        me = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        Rada = GetComponentInChildren<RadaForCrab>();
        Slow = FindObjectOfType<SlowMotion>();

        OriginPoint = transform.position.x;
        Player = FindObjectOfType<controller>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    { 
        if(IsDead == false)
        {
            if (state == State.run && CanAction == true)
            {
                Move();
            }
        }
        timer2 = timer2 + Time.deltaTime;
        if (timer2 > Delaymove)
        {
            CanAction = true;
        }

        anim.SetInteger("state", (int)state); 
    }
    private void Move()
    {   
        if(timer >= Distance)
        {
            state = State.charge;
            timer = 0;
        }
        timer = timer + Time.deltaTime;

        if(player.transform.position.x < transform.position.x) 
        {
            rg.velocity = new Vector2(-RunForce, 0);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            rg.velocity = new Vector2(RunForce, 0);
        }
    }
    public void Attack()
    {
        if(CanAction == true)
        {
           state = State.attack;
        }
    }
    public void BacktoIdle()
    {
        state = State.idle;
    }
    public void DiedReward()
    {
        for(int i=0; i < 3; i++)
        {
            Instantiate(Reward, me.position, me.rotation);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            TakeHit(1);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            TakeHit(1);
        }
        if(collision.gameObject.tag == "Player")
        {
            if (Player.gameObject.transform.position.x > transform.position.x)
            {
                rg.velocity = new Vector2(-hurtforce + 2, hurtforce - 1);
            }
            if (Player.gameObject.transform.position.x < transform.position.x)
            {
                rg.velocity = new Vector2(hurtforce - 2, hurtforce - 1);
            }
            CanAction = false;
            state = State.idle;
            timer2 = 0;
            Slow.DoSlowMotion();

        }
    }
    public void TakeHit(int damage)
    {
        HP -= damage; // Tru mau
        // healthctr.SetHealth(hitpoints, Maxhitpoins);
        Knockback();
        if (HP <= 0)
        {
            IsDead = true;
            Knockback();
            Rada.coll.enabled = false;
            coll.enabled = false;
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
    public void DeleteCorpse()
    {
        Destroy(this.gameObject);
    }
}
