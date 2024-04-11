using UnityEngine;

[CreateAssetMenu(fileName = "Cast2", menuName = "Data/Item effect/Cast2")]
public class CastTwelve : ItemEffect
{
    public int additionalCasts = 2; // Number of additional AirBlades to cast
    public override void ExecuteEffect(Transform _enemyPosition)
    {
        // Find the AirBlade_Effect instance and apply the modifier to it
        AirBlade_Effect airBladeEffect = FindObjectOfType<AirBlade_Effect>();
        Debug.Log(airBladeEffect);
        if (airBladeEffect != null)
        {
            airBladeEffect.additionalCasts = additionalCasts;
        }
        else
        {
            Debug.LogError("AirBlade_Effect instance not found.");
        }
    }
}
