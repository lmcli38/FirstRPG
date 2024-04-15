using UnityEngine;


[CreateAssetMenu(fileName = "SizeModifier", menuName = "Data/Modification/SizeModifier")]
public class SizeModifier : Modification
{
    [SerializeField] Vector3 scaleMultiplier = new Vector3(1.5f, 1.5f, 1.5f);

    public override void ApplyModification(GameObject gameObject)
    {
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, scaleMultiplier);
    }
}
