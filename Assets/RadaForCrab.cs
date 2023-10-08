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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            crab.state = CrabBehavior.State.run;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
