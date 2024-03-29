using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField] PlayerStat playerStats;
    [SerializeField] Slider slider;

    [Header("Curreny INFO")]
    [SerializeField] TextMeshProUGUI currentCurrency;
    [SerializeField] float currencyAmount;
    [SerializeField] float increaseRate = 100; 


    private void Start()
    {
        if(playerStats != null)
            playerStats.onHealthChanged += UpdateHealthUI;
    }

    private void Update()
    {
        UpdateCurrencyUI();
    }

    private void UpdateCurrencyUI()
    {
        if (currencyAmount < PlayerManager.instance.GetCurrency())
            currencyAmount += Time.deltaTime * increaseRate;
        else
            currencyAmount = PlayerManager.instance.GetCurrency();

        currentCurrency.text = ((int)currencyAmount).ToString();
    }

    void UpdateHealthUI()
    {
        slider.maxValue = playerStats.GetMaxHealthValue();
        slider.value = playerStats.currentHealth;
    }
}
