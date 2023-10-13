using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class BarrelScrip : MonoBehaviour
{
    private int hitpoints;
    public int Maxhitpoins = 3;
    public float hurtforce = 0;
    protected Animator anim;
    protected Rigidbody2D rg;
    public Transform me;
    public controller Player;
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;
    public GameObject Reward;
    void Start()
    {
        hitpoints = Maxhitpoins;
        // healthctr.SetHealth(hitpoints, Maxhitpoins);
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<controller>();
        me = GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            TakeHit(1);
        }
    }
    public void TakeHit(int damage)
    {
        hitpoints -= damage; // Tru mau
        // healthctr.SetHealth(hitpoints, Maxhitpoins);
        Knockback();
        anim.SetBool("IsHitted", true);
        if (hitpoints <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(piece1, me.position, me.rotation);
            Instantiate(piece2, me.position, me.rotation);
            Instantiate(piece3, me.position, me.rotation);
            Instantiate(piece4, me.position, me.rotation);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Reward, me.position, me.rotation);
            }
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

    public void BackToIdle()
    {
        anim.SetBool("IsHitted", false);
    }
}
