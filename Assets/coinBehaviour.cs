using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class coinBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int Value;
    public int bounce;
    public Animator anim;
    public CircleCollider2D collision;
    public Rigidbody2D rg;
    public PlayerCoinsManager playerCoinsManager;
    void Start()
    {
        anim = GetComponent<Animator>();   
        collision = GetComponent<CircleCollider2D>();
        rg = GetComponent<Rigidbody2D>();   
        playerCoinsManager = FindObjectOfType<PlayerCoinsManager>();
        GameObject me = GameObject.FindGameObjectWithTag("Item");
        Physics2D.IgnoreCollision(me.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        rg = GetComponent<Rigidbody2D>();
        rg.velocity = new Vector3(UnityEngine.Random.Range(-2f, 2f), 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rg.isKinematic = true;
            anim.SetBool("IsEaten", true);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            rg.isKinematic = true;
            rg.velocity = Vector2.zero;
            playerCoinsManager.CurrentCoins += Value;
        }
    }
    public void Done()
    {
        Destroy(this.gameObject);
    }

}
