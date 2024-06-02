using UnityEngine;


[CreateAssetMenu(fileName = "SpeedModifier", menuName = "Data/Modification/SpeedModifier")]
public class SpeedModifier : Modification
{
    [SerializeField] float speedMultiplier = 15;


    public override void ApplyModifier(AirBlade_AC airBlade)
    {

    }


    public override void ApplyModification(GameObject gameObject)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity *= speedMultiplier;
        }
    }
}
