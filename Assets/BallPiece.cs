using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPiece : MonoBehaviour
{
    public Rigidbody2D rg;
    public Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rg.velocity = new Vector3(UnityEngine.Random.Range(-2.5f, 2.5f), 6);
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
