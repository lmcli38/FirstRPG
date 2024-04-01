using UnityEngine;

public class SIzeModifier : MonoBehaviour
{
    
    public float areaModifier = 2f;
    public void sizeMoifier(EffectModifier _effectModifier)
    {
        _effectModifier.SetArea(_effectModifier.GetArea() * areaModifier);
    }
}
