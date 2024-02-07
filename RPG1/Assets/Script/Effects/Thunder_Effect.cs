using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thunder Effect", menuName = "Data/Item effect/Thunder")]
public class Thunder_Effect : ItemEffect
{
    [SerializeField] GameObject thunderPrefab; 
    
    public override void ExecuteEffect(Transform _enemyPosition)
    {
        GameObject newThunderStrike = Instantiate(thunderPrefab, _enemyPosition.position,Quaternion.identity);

        Destroy(newThunderStrike,1f);
    }
    
}
