using UnityEngine;

public class enemy_0_animationTrigger : MonoBehaviour
{
    private enemy enemy_00 => GetComponentInParent<enemy>();

    private void AnimationTrigger()
    {
        enemy_00.AnimationFinishTrigger();
    }
    void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy_00.attackCheck.position, enemy_00.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                PlayerStat target = hit.GetComponent<PlayerStat>();
                enemy_00.stats.DoDamage(target);
            }
        }
    }

}
