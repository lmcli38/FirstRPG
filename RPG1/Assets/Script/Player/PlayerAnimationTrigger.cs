using System.Collections;
using System.Collections.Generic;
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders) 
        { 
            if(hit.GetComponent<enemy>()  !=  null) 
            {
                EnemyStat _target = hit.GetComponent<EnemyStat>();

                player.stats.DoDamage(_target);


                Inventory.instance.GetEquipment(EquipmentType.Weapon)?.Effect(_target.transform);
                
                /*ItemData_Equipment weaponData = Inventory.instance.GetEquipment(EquipmentType.Weapon);
                if(weaponData != null)
                    weaponData.Effect(_target.transform);*/
            }
        }
    }


    void ThrowSword()
    {
        SkillManager.instance.sword.CreateSword();
    }
}