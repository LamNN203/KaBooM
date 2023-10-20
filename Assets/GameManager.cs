using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager current;
    public PlayerCoinsManager NowCoins;
    public SaveManager saveManager;

    public int coins;
    public int TempHighestCoins;
    void Start()
    {
        current = GetComponent<GameManager>();
        NowCoins = FindObjectOfType<PlayerCoinsManager>();
        saveManager = FindObjectOfType<SaveManager>();
        LoadRecords();
        NowCoins.CurrentCoins = current.coins;
        //SaveRecords();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        current.coins = NowCoins.CurrentCoins;
    }

    private void SaveRecords()
    {
        Data data = SaveManager.GetRecords();
        if (data == null)
            data = new Data();
        data.coins = GetCoinsData();
        SaveManager.SetRecords(data);
    }
    private void LoadRecords()
    {
        Data data = SaveManager.GetRecords();
        if (data != null)
        {
            SetCoinsData(data.coins);
        }
    }
    public static void SetCoinsData(int coin)
    {
        if (current == null)
            return;
        current.coins = coin;
    }

    public static int GetCoinsData()
    {
        if (current == null)
            return 0;
        return current.coins;
    }

    public static void UpdateCoinsData()
    {
        // Update json score
        Debug.Log(current.coins);
        
            Debug.Log("sucess");
            SetCoinsData(current.coins);
            SaveManager.SetRecords(new Data(current.coins));
    }

    public void OnApplicationQuit()
    {
        SaveRecords();
        UpdateCoinsData();
    }

}
