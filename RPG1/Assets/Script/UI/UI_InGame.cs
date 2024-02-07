using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField] PlayerStat playerStats;
    [SerializeField] Slider slider;
    private void Start()
    {
        if(playerStats != null)
            playerStats.onHealthChanged += UpdateHealthUI;
    }

    void UpdateHealthUI()
    {
        slider.maxValue = playerStats.GetMaxHealthValue();
        slider.value = playerStats.currentHealth;
    }
}
