using UnityEngine;

public class EffectModifier : Skill
{
    [Header("ability Info")]
    [SerializeField] GameObject abilityPrefab ;
    [SerializeField] Vector2 launchForce;

    Vector2 FinalDri;

    public void Performability_1()
    {
        GameObject newSword = Instantiate(abilityPrefab, player.transform.position, transform.rotation);

        Debug.Log("ability");
    }
}


