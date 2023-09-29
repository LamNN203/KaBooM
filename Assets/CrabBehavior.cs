using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBehavior : Enemy
{
    // anim
    public enum State { idle, run,charge, attack  }


   
    // frog move
    public float RunForce;
    public float timer;
    public float Distance;
    public State state = State.idle;
    public LayerMask ground;
    public bool Facingleft = true;
    // Moving Limit
    public float OriginPoint;
    public Rigidbody2D rg;
    public Collider2D coll;
    public Transform player;
    public GameObject HitBox;

    protected override void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        base.Start();
        coll = GetComponent<Collider2D>();

        OriginPoint = transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        
        if(state == State.run)
        {
            Move();
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
        state = State.attack;
        Instantiate(HitBox);
    }
    public void BacktoIdle()
    {
        state = State.idle;
    }

}
