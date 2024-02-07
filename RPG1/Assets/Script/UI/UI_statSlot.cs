using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_statSlot : MonoBehaviour
{
    [SerializeField] private string statName;
    [SerializeField] private StatType statType;
    [SerializeField] private TextMeshProUGUI statValueText;
    [SerializeField] private TextMeshProUGUI statNameText;

    void OnValidate()
    {
        gameObject.name = "Stat - " + statName;

        if (statNameText != null)
            statNameText.text = statName;
    }

    private void Start()
    {
        UpdateStatValueUI();
    }
    public void UpdateStatValueUI()
    {
        PlayerStat playerStat = PlayerManager.instance.player.GetComponent<PlayerStat>();

        if (playerStat != null)
        {
            statValueText.text = playerStat.StatToModify(statType).GetValue().ToString();
        }
    }
    
}
