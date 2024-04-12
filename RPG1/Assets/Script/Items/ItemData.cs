using System.Text;
using UnityEditor;
using UnityEngine;

public enum ItemType
{ 
    Material,
    Ability
}



public class ItemData : ScriptableObject
{
    public ItemType itemType;
    public string ItemName;
    public Sprite Icon;
    public string ItemID;

    [Range(0,100)]
    public float dropChance;


    protected StringBuilder sb = new StringBuilder();


    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        ItemID =AssetDatabase.AssetPathToGUID(path);
    }

    public virtual string GetDescription()
    {
        return "";
    }
}

