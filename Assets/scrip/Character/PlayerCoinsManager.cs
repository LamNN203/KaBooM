using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinsManager : MonoBehaviour
{
    public int CurrentCoins;
    public Text CoinsText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = CurrentCoins.ToString();
    }

    public void TakeCoins(int coins)
    {
        CurrentCoins += coins;
    }
}
