using UnityEngine;

public class Weapon : MonoBehaviour
{
    public DistanceModifier distanceModifier;
    public SIzeModifier sIzeModifier;
    public EffectModifier effectModifier;
    public virtual void Attack()
    {
        //perform ability
        //effectModifier.Performability_1();
        
        //increase size
        //sIzeModifier.sizeMoifier();


        //increase distance 
        //distanceModifier.distanceModifier();
    }
}
