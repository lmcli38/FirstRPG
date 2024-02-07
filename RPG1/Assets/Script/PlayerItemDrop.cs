using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemDrop : ItemDrop
{
    [Header("Player's Drop")]
    [SerializeField] float chanceToLooseItems;

    public override void GenerateDrop()
    {
        
    }
}
