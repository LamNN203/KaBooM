using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("MenuScreen")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private GameObject ShopCanvas;

    [Header("Slider")]
    [SerializeField] private Slider loading;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevelBtn(string level)
    {
        MainCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelAsync(level));
    }

    IEnumerator LoadLevelAsync(string level)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(level);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loading.value = progressValue;
            yield return null;
        }
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Timeline");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShopClick()
    {
        MainCanvas.SetActive(false);
        ShopCanvas.SetActive(true);
    }
    public void BackFromShop()
    {
        MainCanvas.SetActive(true);
        ShopCanvas.SetActive(false);
    }



}
