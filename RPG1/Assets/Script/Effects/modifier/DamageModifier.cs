using UnityEngine;
[CreateAssetMenu(fileName = "DamageModifier", menuName = "Data/Modification/DamageModifier")]
public class DamageModifier : Modification
{
    [SerializeField] int AdditionDamage;
    public override void ApplyModification(GameObject gameObject)
    {
        // Get the script responsible for dealing damage
        AirBlade_AC airBladeScript = gameObject.GetComponent<AirBlade_AC>();
        if (airBladeScript != null)
        {
            // Apply additional damage
            //airBladeScript.damage += AdditionDamage;
        }
    }
}

