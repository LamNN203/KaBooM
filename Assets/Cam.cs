
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float FollowSpeed;
    public float yOffset;
    public float xOffset;
    public controller target;
    public Transform thiscam;

    void Start()
    {
        target = FindObjectOfType<controller>();
        thiscam = target.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(thiscam.position.x + xOffset, thiscam.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
