using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPotionManager : MonoBehaviour
{
    public int CurrentPotion;
    public Text PotionText;
    void Start()
    {
        
    }
    void Update()
    {
        SetText();
    }

    public void TakePotion(int a)
    {
        CurrentPotion += a;
    }
    public void SetText()
    {
        PotionText.text = CurrentPotion.ToString();
    }
}
