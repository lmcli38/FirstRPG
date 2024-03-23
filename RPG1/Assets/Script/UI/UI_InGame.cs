using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField] PlayerStat playerStats;
    [SerializeField] Slider slider;


    [SerializeField] TextMeshProUGUI currentCurrency;



    private void Start()
    {
        if(playerStats != null)
            playerStats.onHealthChanged += UpdateHealthUI;
    }

    private void Update()
    {
        currentCurrency.text = PlayerManager.instance.GetCurrency().ToString("#,#");
    }
    void UpdateHealthUI()
    {
        slider.maxValue = playerStats.GetMaxHealthValue();
        slider.value = playerStats.currentHealth;
    }
}
