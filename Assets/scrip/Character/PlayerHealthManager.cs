using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public Image HealthBar;
    public int Health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            //Death
        }
        if (Input.GetKeyUp(KeyCode.H)) { TakeDamage(1); }
        if (Input.GetKeyUp(KeyCode.G)) { Heal(1); }
    }

    public void TakeDamage(int dame)
    {
        Health -= dame;
        HealthBar.fillAmount = Health / 5f;
    }

    public void Heal(int heal)
    {
        Health += heal;
        Health = Mathf.Clamp(Health, 0, 5);

        HealthBar.fillAmount = Health / 5f;
    }
}
