using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    public Transform subject;
    Vector2 StartPos;
    float startZ;
    Vector2 travle => (Vector2)cam.transform.position - StartPos;
    Vector2 parallaxFactor;
    void Start()
    {
        StartPos = transform.position;
        startZ = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = StartPos + travle;
    }
}
