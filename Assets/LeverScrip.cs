using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScrip : MonoBehaviour
{
    public Animator anim;
    public Collider2D col;
    public Shaking shake;
    public bool Up = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        shake = GetComponent<Shaking>();

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            anim.SetBool("Trigger", true);
            Up = true;
            shake.BasicShake(3f, 4f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
