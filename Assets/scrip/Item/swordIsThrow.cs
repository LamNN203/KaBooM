using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordIsThrow : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rg;
    public Collider2D col;
    public GameObject SwordItem;
    public bool firstCol = false;

    private void Awake()
    {
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (firstCol == true)
        {
            anim.SetBool("Embeded", true);
            transform.rotation = Quaternion.Euler(0, 0, -90);
            rg.velocity = new Vector2(0, 0);
        }


    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (firstCol == false)
        {
            anim.SetBool("Bounce", true);
            firstCol = true;
        }
       
    }

    public void se()
    {
        Destroy(this.gameObject);
        Instantiate(SwordItem, transform.position, transform.rotation);
    }
}
