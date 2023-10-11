using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceParticle : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rg;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject coins = GameObject.FindGameObjectWithTag("Item");
        Physics2D.IgnoreCollision(coins.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = new Vector3(UnityEngine.Random.Range(-2.5f, 2.5f), 4);
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
