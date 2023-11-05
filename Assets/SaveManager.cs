using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    static SaveManager current;
    private string CoinsDataFilename = "Data.json";

    private Data records;
    void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void SetRecords(Data records)
    {
        if (current == null || records == null)
            return;
        current.records = records;
        current.SaveRecords();
    }

    public static Data GetRecords()
    {
        if (current == null)
            return null;

        if (current.records == null)
            current.LoadRecords();
        return current.records;
    } 

    void SaveRecords()
    {
        if (records == null)
            LoadRecords();
        string jsonData = JsonUtility.ToJson(records);
        string filePath = Path.Combine(Application.persistentDataPath, CoinsDataFilename);
        File.WriteAllText(filePath, jsonData);
        Debug.Log(filePath);
        Debug.Log(jsonData);

    }

    void LoadRecords()
    {
        if (records != null) // prevent double loading
        {
            records = new Data();
            return;
        }

        // Path.Combine combines strings into a file path
        string filePath = Path.Combine(Application.persistentDataPath, CoinsDataFilename);
        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            records = JsonUtility.FromJson<Data>(dataAsJson);
        }
        else
            records = new Data();
    }
}
