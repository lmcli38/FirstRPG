using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Data", menuName = "Data/Heal effect")]
public class Heal_Effect : ItemEffect
{
    [Range(0f, 1f)]
    [SerializeField] float healPercent;


    public override void ExecuteEffect(Transform _enemyPosition)
    {
        PlayerStat playerStat = PlayerManager.instance.player.GetComponent<PlayerStat>();

        int healAmount = Mathf.RoundToInt(playerStat.GetMaxHealthValue() * healPercent);

        playerStat.IncreaseHealth(healAmount);

    }
}
