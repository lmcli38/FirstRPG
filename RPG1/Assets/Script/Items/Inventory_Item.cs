using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Inventory_Item
{  
    public ItemData itemData;
    public int stackSize;
    public Inventory_Item(ItemData _newitemData)
    {
        itemData = _newitemData;
        AddStack();
    }
    public void AddStack() => stackSize++;
    public void RemoveStack() => stackSize--;


}
