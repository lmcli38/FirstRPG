using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField]int baseValue;
    public List<int> modfiers;
    public int GetValue()
    {
        int finalValue = baseValue;

        foreach (int modfier in modfiers)
        {
            finalValue += modfier;
        }
        return finalValue;
    }
    public void SetDefaultValue(int _value)
    {
        baseValue = _value;
    }

    public void AddModifier(int _modfier)
    {
        modfiers.Add(_modfier);
    }
    public void RemoveModifier(int _modifier)
    {
        modfiers.Remove(_modifier);
    }
}
