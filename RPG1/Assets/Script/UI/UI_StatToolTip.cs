using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_StatToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statText;
    [SerializeField] private TextMeshProUGUI statName;

    public void ShowToolTip(string _statDescription, string _statName)
    {
        statName.text = _statName;
        statText.text = _statDescription;
        gameObject.SetActive(true);
    }
    public void HideToolTip() => gameObject.SetActive(false);
}
