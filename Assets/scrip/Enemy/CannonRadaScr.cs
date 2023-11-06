using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRadaScr : MonoBehaviour
{
    public Collider2D Rada;
    public CannonTrapScp TurnOn;
    
    void Start()
    {
        Rada = GetComponent<Collider2D>();
        TurnOn = GetComponentInParent<CannonTrapScp>();
        GameObject player = GameObject.FindGameObjectWithTag("PlayerHitBox");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Update()
    {
        GameObject[] GameObj = GameObject.FindGameObjectsWithTag("PlayerHitBox");
        foreach (GameObject Obj in GameObj)
        {
            Physics2D.IgnoreCollision(Obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TurnOn.CanShoot = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TurnOn.CanShoot = false;
        }
    }
}
