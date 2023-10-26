using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadaForCrab : MonoBehaviour
{
    public CrabBehavior crab;
    public BoxCollider2D coll;
    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        crab = GetComponentInParent<CrabBehavior>();
        //GameObject[] GameObj = GameObject.FindGameObjectsWithTag("PlayerHitBox");
        //foreach (GameObject Obj in GameObj)
        //{
        //    Physics2D.IgnoreCollision(Obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}
        GameObject player = GameObject.FindGameObjectWithTag("PlayerHitBox");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(crab.CanAction == true)
            {
                crab.state = CrabBehavior.State.run;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //GameObject[] GameObj = GameObject.FindGameObjectsWithTag("PlayerHitBox");
        //foreach (GameObject Obj in GameObj)
        //{
        //    Physics2D.IgnoreCollision(Obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}
        GameObject[] GameObj = GameObject.FindGameObjectsWithTag("PlayerHitBox");
        foreach (GameObject Obj in GameObj)
        {
            Physics2D.IgnoreCollision(Obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
