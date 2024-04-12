using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    Player player => GetComponentInParent<Player>();

    void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    void AttackTrigger()
    {
         AudioManager.instance.PlaySFX(2, null); //PLay attack sound effect

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<enemy>() != null)
            {
                EnemyStat _target = hit.GetComponent<EnemyStat>();
                string enemyName = hit.gameObject.name;

                if (hit.GetComponent<enemy>().CanBeStunned())
                {
                    player.stats.DoDamage(_target);
                }
                if(enemyName == "boss_1")
                    player.stats.DoDamage(_target);

                Inventory.instance.GetEquipment(EquipmentType.Effect)?.Effect(_target.transform);

                /*ItemData_Equipment weaponData = Inventory.instance.GetEquipment(EquipmentType.Weapon);
                if(weaponData != null)
                    weaponData.Effect(_target.transform);*/
            }
        }
    }


    void ThrowSword()
    {
        SkillManager.instance.sword.CreateAirBlade();

    }

}
