using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCrab : MonoBehaviour
{
    public Collider2D col;
    public controller Player;
    void Start()
    {
        col = GetComponent<Collider2D>();
        Player = FindObjectOfType<controller>();
    }

    public void OnTriggerEnter2D(Collider2D others)
    {
        if (others.gameObject.tag == "Player")
        {
            
        }
    }
    
}