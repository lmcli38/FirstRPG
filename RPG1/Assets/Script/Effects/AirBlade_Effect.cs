using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AirBlade", menuName = "Data/Item effect/AirBlade")]
public class AirBlade_Effect : ItemEffect 
{ 
    [SerializeField] GameObject AirBladePrefab;
    public override void ExecuteEffect(Transform _enemyPosition)
    {
        GameObject newAirBlade = Instantiate(AirBladePrefab);

        Destroy(newAirBlade, 1f);
    }
}
