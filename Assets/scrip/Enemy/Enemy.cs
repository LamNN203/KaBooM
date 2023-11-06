using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //protected Animator anim;
    //public controller Player;
    //private int hitpoints;
    //public int Maxhitpoins = 3;
    //public int hurtforce = 0;
    //protected Rigidbody2D rg;

    //// Start is called before the first frame update
    //protected virtual void Start()
    //{
    //    hitpoints = Maxhitpoins;
    //    anim = GetComponent<Animator>();
    //    rg = GetComponent<Rigidbody2D>();
    //    Player = FindObjectOfType<controller>();
    //}

    //public void OnHit()
    //{

    //}

    //public void OnDeath()
    //{    
    //    anim.SetBool("IsDeath", true);
    //    Debug.Log("death");
    //}
    //// Update is called once per frame

    //public void DeleteCorpse()
    //{
    //    Destroy(this.gameObject);
    //}
    //public void TakeHit(int damage)
    //{
    //    hitpoints -= damage; // Tru mau
    //    // healthctr.SetHealth(hitpoints, Maxhitpoins);
    //    Knockback();
    //    if (hitpoints <= 0)
    //    {
    //        OnDeath();
    //    }
    //}
    //public void Knockback()
    //{
    //    if (Player.gameObject.transform.position.x > transform.position.x)
    //    {
    //        rg.velocity = new Vector2(-hurtforce, hurtforce - 1);
    //    }
    //    if (Player.gameObject.transform.position.x < transform.position.x)
    //    {
    //        rg.velocity = new Vector2(hurtforce, hurtforce - 1);
    //    }
    //}
    //void Update()
    //{
        
    //}


}
