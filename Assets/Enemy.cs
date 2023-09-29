using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    [SerializeField] protected Rigidbody2D rb;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnHit()
    {

    }

    public void OnDeath()
    {
        Destroy(this.gameObject);
        rb.velocity = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
