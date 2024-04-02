using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int currency;
    public SER_Dictionary<string, int> inventory;
    public List<string> equipmentId;


    public SER_Dictionary<string, float> volumeSetting;

    public GameData()
    {
        this.currency = 0;
        inventory = new SER_Dictionary<string, int>();

        equipmentId = new List<string>();


        volumeSetting = new SER_Dictionary<string, float>();
    }
}
