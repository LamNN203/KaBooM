using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScr : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rg;
    public Collider2D col;
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public Transform me;


    void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        me = GetComponent<Transform>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Explose");
        col.isTrigger = true;
        rg.isKinematic = true;
        rg.velocity= new Vector2 (0,0);
        Instantiate(piece1, me.position, me.rotation);
        Instantiate(piece2, me.position, me.rotation);
        Instantiate(piece3, me.position, me.rotation);
    }
    public void Explose()
    {
        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
