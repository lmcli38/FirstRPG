using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EquipmentSlot : UI_ItemSlot
{
    public EquipmentType SlotType;

    private  void OnValidate()
    {
        gameObject.name = "Equipment slot - " + SlotType.ToString();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (item == null || item.itemData == null) return;


        Inventory.instance.UnEquipItem(item.itemData as ItemData_Equipment);
        Inventory.instance.AddItem(item.itemData as ItemData_Equipment);

        CleanUPSlot();
    }
}
