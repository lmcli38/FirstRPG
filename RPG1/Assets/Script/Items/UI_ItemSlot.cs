using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemSlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private Image itemImage;
    [SerializeField]private TextMeshProUGUI ItemText;

    public Inventory_Item item;
    private UI ui;
    void Start()
    {
        ui = GetComponentInParent<UI>();
    }
    public void UpdateSlot(Inventory_Item _newitem)
    {
        item = _newitem;
        itemImage.color = Color.white;
        if (item != null)
        {
            itemImage.sprite = item.itemData.Icon;
            if (item.stackSize > 1)
            {
                ItemText.text = item.stackSize.ToString();
            }
            else
            {
                ItemText.text = "";
            }
        }
    }
    public void CleanUPSlot()
    {
        item = null;

        itemImage.sprite = null;
        itemImage.color = Color.clear;
        ItemText.text = "";
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if(item == null)
        {
            return;
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            Inventory.instance.RemoveItem(item.itemData);
            return;
        }

        if(item.itemData.itemType == ItemType.Equipment) 
        {
            Inventory.instance.EquipItem(item.itemData);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item == null)
            return;

            


        ui.itemToolTip.ShowToolTip(item.itemData as ItemData_Equipment);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(item == null)
            return;
        ui.itemToolTip.HideToolTip();
    }
}
