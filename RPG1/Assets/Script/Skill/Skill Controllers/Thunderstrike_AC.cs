using UnityEngine;

public class Thunderstrike_AC : EffectModifier
{ 
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<enemy>() != null)
        {
            PlayerStat playerStat = PlayerManager.instance.player.GetComponent<PlayerStat>();
            EnemyStat enemyTarget = collision.GetComponent<EnemyStat>();

            playerStat.DoMagicalDamage(enemyTarget);
        }

    }

}
