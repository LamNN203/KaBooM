using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public float Times;
    public string SceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Times -= Time.deltaTime;
        if ( Times < 0)
        {
            SceneManager.LoadScene(SceneName);
        }

    }
}
