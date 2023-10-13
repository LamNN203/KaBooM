using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

}
