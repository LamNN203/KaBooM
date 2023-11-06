using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScrips : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public float Deadzone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * Speed) * Time.deltaTime;
        if(transform.position.x < Deadzone)
        {
            Destroy(gameObject);
        }
    }
}
