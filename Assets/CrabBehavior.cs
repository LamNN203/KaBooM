using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBehavior : Enemy
{
    public CapsuleCollider2D coll;
    public float MoveSp;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
