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
        anim.SetBool("IsDeath", true);
        Debug.Log("death");
    }
    // Update is called once per frame

    public void DeleteCorpse()
    {
        Destroy(this.gameObject);
    }
    void Update()
    {
        
    }


}
