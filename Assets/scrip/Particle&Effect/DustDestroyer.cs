using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustDestroyer : MonoBehaviour
{
    public float Dustrate;
    private float timer;
    // Start is called before the first frame update
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
