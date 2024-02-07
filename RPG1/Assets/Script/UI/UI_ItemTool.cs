using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ItemTool : UI_ToolTIp
{
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemTypeText;
    [SerializeField] TextMeshProUGUI itemDescription;

    public void ShowToolTip(ItemData_Equipment _item)
    {
        if(_item == null)
            return;
        itemNameText.text = _item.ItemName;
        itemTypeText.text = _item.equipmentType.ToString();
        itemDescription.text = _item.GetDescription();

        AdjustFontSize(itemTypeText);
        AdjustPosition();
        gameObject.SetActive(true);
    }

    public void HideToolTip() => gameObject.SetActive(false);
    
}
