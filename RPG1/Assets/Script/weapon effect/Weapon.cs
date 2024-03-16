using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public EffectModifier effectModifier;
    public void UseWeapon()
    {
        // Apply the effect modifier's effect here
        // Example: Increase damage by the modifier value
        int damageIncrease = effectModifier != null ? effectModifier.modifierValue : 0;
        Debug.Log("Applying effect modifier: " + effectModifier.modifierName + " +" + damageIncrease + " damage");
    }
}
