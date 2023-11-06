using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float SlowFactor = 0.1f;
    public float slowLength = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale += (1f / slowLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f,1f);
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void DoSlowMotion()
    {
        Time.timeScale = SlowFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
      
    }
}
