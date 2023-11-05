using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager current;
    public PlayerCoinsManager NowCoins;
    public PlayerPotionManager NowPotions;
    public SaveManager saveManager;

    public int coins;
    public int potions;
    public int TempHighestCoins;
    void Start()
    {
        current = GetComponent<GameManager>();
        NowCoins = FindObjectOfType<PlayerCoinsManager>();
        NowPotions = FindObjectOfType<PlayerPotionManager>();
        saveManager = FindObjectOfType<SaveManager>();
        LoadRecords();
        NowCoins.CurrentCoins = current.coins;
        NowPotions.CurrentPotion = current.potions;
        //SaveRecords();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        current.coins = NowCoins.CurrentCoins;
        current.potions = NowPotions.CurrentPotion;
    }

    private void SaveRecords()
    {
        Data data = SaveManager.GetRecords();
        if (data == null)
            data = new Data();
        data.coins = GetCoinsData();
        data.potion = GetPotionData();
        SaveManager.SetRecords(data);
    }
    private void LoadRecords()
    {
        Data data = SaveManager.GetRecords();
        if (data != null)
        {
            SetCoinsData(data.coins);
            SetPotionData(data.potion);
        }
    }
    public static void SetCoinsData(int coin)
    {
        if (current == null)
            return;
        current.coins = coin;
    }
    public static void SetPotionData(int potion)
    {
        if (current == null)
            return;
        current.potions = potion;
    }
    public static int GetPotionData()
    {
        if (current == null)
            return 0;
        return current.potions;
    }

    public static int GetCoinsData()
    {
        if (current == null)
            return 0;
        return current.coins;
    }

    public static void UpdateData()
    {
        // Update json score
        SetCoinsData(current.coins);
        SetPotionData(current.potions); 
        SaveManager.SetRecords(new Data(current.coins, current.potions));
    }

    public void BuyPotion()
    {
        if (NowCoins.CurrentCoins > 1)
        {
            NowCoins.CurrentCoins -= 2;
            current.coins = NowCoins.CurrentCoins;
            NowPotions.CurrentPotion += 1;
            current.potions = NowPotions.CurrentPotion;
            UpdateData();
        }
        
    }

    public void BuySkull()
    {
        if (NowCoins.CurrentCoins > 9)
        {
            NowCoins.CurrentCoins -= 10;
            current.coins = NowCoins.CurrentCoins;

            UpdateData();
        }

    }

    public void Setting()
    {

    }

    public void OnApplicationQuit()
    {
        SaveRecords();
        UpdateData();
    }

}
