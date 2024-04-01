using UnityEngine;

public class EffectModifier : MonoBehaviour
{
    protected float area = 1f;
    protected float duration = 1f;

    public void SetArea(float newArea)
    {
        area = newArea;
    }

    public float GetArea()
    {
        return area;
    }

    public void SetDuration(float newDuration)
    {
        duration = newDuration;
    }

    public float GetDuration()
    {
        return duration;
    }
}


