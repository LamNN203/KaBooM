using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cloud;
    public float SpawnRate;
    public float timer = 0;
    void Start()
    {
        SpawnClouds();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < SpawnRate)
        {
            timer =timer + Time.deltaTime;
        }
        else
        {
            SpawnClouds();
            timer = 0;
        }
    }
    public void SpawnClouds()
    {
        Instantiate(Cloud,transform.position, transform.rotation);
    }
}
