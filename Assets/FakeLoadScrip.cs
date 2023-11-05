using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FakeLoadScrip : MonoBehaviour
{
    public GameObject thisCanvas;
    public GameObject Controler;
    public Slider timeSlide;
    public float slidertime;
    public bool timer = false;
    void Start()
    {
        timeSlide.maxValue = slidertime;
        timeSlide.value = 0;
        StartTimer();
    }
    public void StartTimer()
    {
        StartCoroutine(StartTimers());
    }
    IEnumerator StartTimers()
    {
        while (timer == false)
        {
            timeSlide.value += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);

            if (timeSlide.value >= slidertime )
            {
                thisCanvas.SetActive(false);
                Controler.SetActive(true);
                timer = true;
                StopTimer();
            }
        }
    }

    public void StopTimer()
    {
        timer = true;
    }

}
