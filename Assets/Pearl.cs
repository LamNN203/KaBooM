using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    public Rigidbody2D rg;
    public Collider2D col;
    public Transform me;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        col.isTrigger = true;
        rg.isKinematic = true;
        rg.velocity = new Vector2(0, 0);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
