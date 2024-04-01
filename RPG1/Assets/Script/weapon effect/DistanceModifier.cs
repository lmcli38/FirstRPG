using UnityEngine;

public class DistanceModifier : MonoBehaviour
{
    public float durationModifier = 1f;
    public void distanceModifier(EffectModifier _effectModifier)
    {
        _effectModifier.SetDuration(_effectModifier.GetDuration()*durationModifier);
    }
}
