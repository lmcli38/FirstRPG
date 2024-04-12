using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour, ISaveManager
{
    public static Inventory instance;

    public List<ItemData> startItems;

    public List<Inventory_Item> equipment;
    public Dictionary<ItemData_Equipment, Inventory_Item> equipmentDictionary;

    public List<Inventory_Item> stash;
    public Dictionary<ItemData, Inventory_Item> stashDictonary;

    public List<Inventory_Item> inventoryItems;
    public Dictionary<ItemData, Inventory_Item> inventoryDictionary;

    [Header("Data base")]
    public List<Inventory_Item> loadedItems;
    public List <ItemData_Equipment> loadedEquipment;


    [Header("Inventory UI")]

    [SerializeField] private Transform InventorySlotParent;
    [SerializeField] private Transform StashSlotParent;
    [SerializeField] private Transform equipmwntSlotParent;
    [SerializeField] private Transform statSlotParent;

    private UI_ItemSlot[] itemSlot;
    private UI_ItemSlot[] stashItemSlot;
    private UI_EquipmentSlot[] equipmentSlot;
    private UI_statSlot[] statSlot;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        inventoryItems = new List<Inventory_Item>();
        inventoryDictionary = new Dictionary<ItemData, Inventory_Item>();

        stash = new List<Inventory_Item>();
        stashDictonary = new Dictionary<ItemData, Inventory_Item>();

        equipment = new List<Inventory_Item>();
        equipmentDictionary = new Dictionary<ItemData_Equipment, Inventory_Item>();

        itemSlot = InventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();
        stashItemSlot = StashSlotParent.GetComponentsInChildren<UI_ItemSlot>();
        equipmentSlot = equipmwntSlotParent.GetComponentsInChildren<UI_EquipmentSlot>();
        statSlot = statSlotParent.GetComponentsInChildren<UI_statSlot>();

        AddStartItems();
    }

    private void AddStartItems()
    {
        foreach(ItemData_Equipment item in loadedEquipment)
        {
            EquipItem(item);
        }


        if(loadedItems.Count > 0)
        {
            foreach(Inventory_Item item in loadedItems)
            {
                for (int i = 0; i < item.stackSize; i++)
                {
                    AddItem(item.itemData);
                }
            }
            return;
        }

        for (int i = 0; i < startItems.Count; i++)
        {
            AddItem(startItems[i]);
        }
    }

    public void EquipItem(ItemData _item)
    {
        ItemData_Equipment newEquipment = _item as ItemData_Equipment;
        Inventory_Item newItem = new Inventory_Item(newEquipment);

        ItemData_Equipment oldEquipment = null;
        foreach (KeyValuePair<ItemData_Equipment, Inventory_Item> item in equipmentDictionary)
        {
            if (item.Key.equipmentType == newEquipment.equipmentType)
            {
                oldEquipment = item.Key;
            }
        }
        if(oldEquipment != null) 
        { 
            UnEquipItem(oldEquipment);
            AddItem(oldEquipment);
        }
        equipment.Add(newItem);
        equipmentDictionary.Add(newEquipment, newItem);
        RemoveItem(_item);
        newEquipment.AddModifier();

        UpdateSlotUI();
    }

    public void UnEquipItem(ItemData_Equipment itemToRemove)
    {
        if (equipmentDictionary.TryGetValue(itemToRemove, out Inventory_Item value))
        {
            equipment.Remove(value);
            equipmentDictionary.Remove(itemToRemove);
            itemToRemove.RemoveModifier();
        }
    }

    private void UpdateSlotUI()
    {
        for(int i = 0; i< equipmentSlot.Length; i++)
        {
            foreach (KeyValuePair<ItemData_Equipment, Inventory_Item> item in equipmentDictionary)
            {
                if (item.Key.equipmentType == equipmentSlot[i].SlotType)
                {
                    equipmentSlot[i].UpdateSlot(item.Value);
                }
            }
        }


        for(int i = 0; i< itemSlot.Length; i++)
        {
            itemSlot[i].CleanUPSlot();
        }
        for (int i = 0; i < stashItemSlot.Length; i++)
        {
            stashItemSlot[i].CleanUPSlot();
        }


        for (int i =0; i< inventoryItems.Count; i++) 
        {
            itemSlot[i].UpdateSlot(inventoryItems[i]);
        }
        for(int i = 0; i < stash.Count; i++)
        {
            stashItemSlot[i].UpdateSlot(stash[i]);
        }
        for(int i = 0; i<statSlot.Length; i++) // Update info of stat in character UI
        {
            statSlot[i].UpdateStatValueUI();
        }
    }

    public bool CanAddItem()
    {
        if(inventoryItems.Count >= itemSlot.Length)
            return false;

        return true;
    }
    public void AddItem(ItemData _item)
    {
        if(_item.itemType == ItemType.Ability && CanAddItem()) 
        { 
            AddToInventory(_item);
        }
        else if( _item.itemType == ItemType.Material)
        {
            AddToStash(_item);
        }

        UpdateSlotUI();
    }

    private void AddToStash(ItemData _item)
    {
        if (stashDictonary.TryGetValue(_item, out Inventory_Item value))
        {
            value.AddStack();
        }
        else
        {
            Inventory_Item newItem = new Inventory_Item(_item);
            stash.Add(newItem);
            stashDictonary.Add(_item, newItem);
        }
    }

    private void AddToInventory(ItemData _item)
    {
        if (inventoryDictionary.TryGetValue(_item, out Inventory_Item value))
        {
            value.AddStack();
        }
        else
        {
            Inventory_Item newItem = new Inventory_Item(_item);
            inventoryItems.Add(newItem);
            inventoryDictionary.Add(_item, newItem);
        }
    }

    public void RemoveItem(ItemData _item) 
    {
        if(inventoryDictionary.TryGetValue(_item, out Inventory_Item value))
        {
            if(value.stackSize<=1)
            {
                inventoryItems.Remove(value);
                inventoryDictionary.Remove(_item);
            }
            else
            {
                value.RemoveStack();
            }
        }

        if(stashDictonary.TryGetValue(_item, out Inventory_Item stashValue ))
        {
            if(stashValue.stackSize<=1)
            {
                stash.Remove(stashValue);
                stashDictonary.Remove(_item);
            }
            else
            {
                stashValue.RemoveStack();
            }
        }
        UpdateSlotUI() ;
    }

    public ItemData_Equipment GetEquipment(EquipmentType _type)
    {
        ItemData_Equipment equipedItem = null;

        foreach (KeyValuePair<ItemData_Equipment, Inventory_Item> item in equipmentDictionary)
        {

            if (item.Key.equipmentType == _type)
            {
                equipedItem = item.Key;
            }
        }

        return equipedItem;
    }

    public void LoadData(GameData _data)
    {
        foreach(KeyValuePair<string, int> pair in _data.inventory)
        {
            foreach(var item in GetItemDataBase())
            {
                if(item != null && item.ItemID == pair.Key)
                {
                    Inventory_Item itemToLoad = new Inventory_Item(item);
                    itemToLoad.stackSize = pair.Value;

                    loadedItems.Add(itemToLoad);
                }
            }
        }
        foreach(string loadeditemId in _data.equipmentId)
        {
            foreach (var item in GetItemDataBase())
            {
                if(item !=null && item.ItemID == loadeditemId)
                {
                    loadedEquipment.Add(item as ItemData_Equipment);
                }
            }
        }

    }

    public void SaveData(ref GameData _data)
    {
        _data.inventory.Clear();
        _data.equipmentId.Clear();

        foreach(KeyValuePair<ItemData, Inventory_Item> pair in inventoryDictionary)
        {
            _data.inventory.Add(pair.Key.ItemID, pair.Value.stackSize);
        }
        foreach (KeyValuePair<ItemData,Inventory_Item> pair in stashDictonary)
        {
            _data.inventory.Add(pair.Key.ItemID, pair.Value.stackSize);
        }

        foreach(KeyValuePair<ItemData_Equipment, Inventory_Item> pair in equipmentDictionary)
            _data.equipmentId.Add(pair.Key.ItemID);
    }


    private List<ItemData> GetItemDataBase()
    {
        List<ItemData> itemDataBase = new List<ItemData>();
        string[] assetNames = AssetDatabase.FindAssets("", new[] { "Assets/Data/Item" });
        foreach (string SOName in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var itemData = AssetDatabase.LoadAssetAtPath<ItemData>(SOpath);

            itemDataBase.Add(itemData);
        }
        return itemDataBase;
    }
}
