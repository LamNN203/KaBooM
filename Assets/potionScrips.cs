using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionScrips : MonoBehaviour
{
    public int Value;
    public Animator anim;
    public Collider2D collision;
    public Rigidbody2D rg;
    public PlayerHealthManager playerHealthManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        collision = GetComponent<Collider2D>();
        rg = GetComponent<Rigidbody2D>();
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
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
            gameObject.GetComponent<Collider2D>().enabled = false;
            rg.isKinematic = true;
            rg.velocity = Vector2.zero;
            playerHealthManager.Heal(Value);
        }
    }
    public void Done()
    {
        Destroy(this.gameObject);
    }

}
