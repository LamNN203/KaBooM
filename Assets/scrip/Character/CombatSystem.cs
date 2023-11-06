using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public GameObject meleehitbox;
    public BoxCollider2D meleeTrigger;
    void Start()
    {
        meleeTrigger = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            Debug.Log("hit");
        }
    }
}
