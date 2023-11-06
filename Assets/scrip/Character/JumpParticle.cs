using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpParticle : MonoBehaviour
{
    public float Dustrate;
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Dustrate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}
