using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderstrike_AC : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<enemy>() != null)
        {
            PlayerStat playerStat = PlayerManager.instance.player.GetComponent<PlayerStat>();     
            EnemyStat enemyTarget = collision.GetComponent<EnemyStat>();

            playerStat.DoMagicalDamage(enemyTarget);
        }

    }

}
