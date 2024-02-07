using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "Buff effect", menuName ="Data/Item effect/Buff effect")]
public class Buff_Effect : ItemEffect
{
    PlayerStat stats;
    [SerializeField] StatType buffType;
    [SerializeField] int buffAmount;
    [SerializeField] int buffDuration;

    public override void ExecuteEffect(Transform _enemyPosition)
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStat>();

        stats.InceaseStatBy(buffAmount, buffDuration, stats.StatToModify(buffType));
    }


}
