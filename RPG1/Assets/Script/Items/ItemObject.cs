using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    [SerializeField] Rigidbody2D rb;

    private void SetUpVisuals()
    {
        if (itemData == null)
            return;
        GetComponent<SpriteRenderer>().sprite = itemData.Icon;
        gameObject.name = "Item object - " + itemData.ItemName;
    }

    public void SetUpItem(ItemData _itemData,Vector2 _velocity)
    {
        itemData = _itemData;
        rb.velocity = _velocity;

        SetUpVisuals();
    }

    public void PickItem()
    {
        if(!Inventory.instance.CanAddItem() && itemData.itemType ==     ItemType.Ability)
            { return; }
        Inventory.instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
