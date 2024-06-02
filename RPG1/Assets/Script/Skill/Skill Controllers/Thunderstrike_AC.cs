using UnityEngine;

public class Thunderstrike_AC : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<enemy>() != null)
        {
            PlayerStat playerStat = PlayerManager.instance.player.GetComponent<PlayerStat>();
            EnemyStat enemyTarget = collision.GetComponent<EnemyStat>();
            playerStat.DoMagicalDamage(enemyTarget, 1.5f);

            /*
            enemy enemy0 = collision.GetComponent<enemy>();
            player.stats.DoDamage(enemy0.GetComponent<CharacterStats>());*/
        }

    }

}
