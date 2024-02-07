using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_skill : Skill
{
    [SerializeField] float fireballDuration;
    [SerializeField] GameObject fireballPrefab;
    GameObject currentFireBall;

    [Header("Explosive fireball")]
    [SerializeField] bool canExplosive;

    [Header("Moving fireball")]
    [SerializeField] bool canMoveToEnemy;
    [SerializeField] float moveSpeed;


    public override void UseSkill()
    {
        base.UseSkill();

        if(currentFireBall == null) 
        {
            currentFireBall = Instantiate(fireballPrefab, player.transform.position, Quaternion.identity);
            FireBall_AC currentScript = currentFireBall.GetComponent<FireBall_AC>();

            currentScript.SetUpFireBall(fireballDuration,canExplosive,canMoveToEnemy,moveSpeed);
        }
        else
        {
            Vector2  playerPos = player.transform.position;

            player.transform.position = currentFireBall.transform.position;

            currentFireBall.transform.position= playerPos;
            currentFireBall.GetComponent<FireBall_AC>()?.FinishFireBall();
        }
    }
}

