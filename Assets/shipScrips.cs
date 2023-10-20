using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shipScrips : MonoBehaviour
{
    public Collider2D col;
    public SaveManager saveManager;

    [Header("MenuScreen")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject MainCanvas;

    [Header("Slider")]
    [SerializeField] private Slider loading;

    void Start()
    {
        col = GetComponent<Collider2D>();
        saveManager = FindObjectOfType<SaveManager>();     
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            LoadLevelBtn("PirateShip");
        }
        
    }
    void Update()
    {
        
    }
    public void LoadLevelBtn(string level)
    {
        MainCanvas.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelAsync(level));
    }

    IEnumerator LoadLevelAsync(string level)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(level);

        while(!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loading.value = progressValue;
            yield return null;
        }
    }
}
