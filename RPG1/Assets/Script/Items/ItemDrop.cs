using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] int possibleItemDrop;
    [SerializeField] private ItemData[] possibileDrop;
    List<ItemData> dropList = new List<ItemData>();

    [SerializeField] GameObject dropPrefab;


    public virtual void GenerateDrop()
    {
        if (possibileDrop.Length <= 0)
            return;
        for(int i = 0; i < possibileDrop.Length; i++) 
        { 
            if(Random.Range(0,10) <= possibileDrop[i].dropChance)
                dropList.Add(possibileDrop[i]);
        }

        for (int i = 0; i< possibleItemDrop; i++)
        {
            if (dropList.Count > 0)
                return;
            ItemData randomItem = dropList[Random.Range(0,dropList.Count-1)];

            dropList.Remove(randomItem);
            DropItem(randomItem);

        }
    }

    protected void DropItem(ItemData _itemData)
    {
        GameObject newDrop = Instantiate(dropPrefab, transform.position, Quaternion.identity);

        Vector2 randomVelocity = new Vector2(Random.Range(-5, 5), Random.Range(12, 15));

        newDrop.GetComponent<ItemObject>().SetUpItem(_itemData, randomVelocity);
    }

}
