using UnityEngine;

public abstract class Modification : ScriptableObject
{
    public string modifierName;
    public abstract void ApplyModification(GameObject gameObject);

    public abstract void ApplyModifier(AirBlade_AC airBlade);

}
