using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlade_AC : MonoBehaviour
{
    private PlayerStat playerStats;

    void Start()
    {
        playerStats = PlayerManager.instance.GetComponent<PlayerStat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<enemy>() != null) 
        {
            EnemyStat enemyTarget = collision.GetComponent<EnemyStat>();

            playerStats.DoDamage(enemyTarget);
        }
    }


}
