using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGrondScrips : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D col;
    public LeverScrip Ups;

    public Transform target;
    public float Speed;
    void Start()
    {
        col = GetComponent<Collider2D>();
        Ups = FindObjectOfType<LeverScrip>();
    }

    
    void FixedUpdate()
    {
        if ( Ups.Up == true)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
