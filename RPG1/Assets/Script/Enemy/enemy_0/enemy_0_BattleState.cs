using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_BattleState : enemyState
{
    enemy_0 enemy_00;
    Transform player;
    int moveDir;
    public enemy_0_BattleState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, enemy_0 enemy_00) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy_00 = enemy_00;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;

        if (player.GetComponent<PlayerStat>().isDead)
            stateMachine.ChangeState(enemy_00.moveState);
    }


    public override void Update()
    {
        base.Update();

        if (enemy_00.IsPlayerDetected())
        {
            stateTimer = enemy_00.battleTime;
            if(enemy_00.IsPlayerDetected().distance < enemy_00.attackDistance)
            {
                if(CanAttack())
                    {
                    stateMachine.ChangeState(enemy_00.attackState);
                    }
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position,enemy_00.transform.position)>7)
            {
                stateMachine.ChangeState(enemy_00.idleState);
            }
        }



        if(player.position.x >enemy_00.transform.position.x) 
        {
            moveDir = 1;
        }
        else if (player.position.x < enemy_00.transform.position.x)
        {
            moveDir = -1;
        }
        enemy_00.SetVelocity(enemy_00.movespeed * moveDir, rb.velocity.y);
    }
    public override void Exit()
    {
        base.Exit();
    }

    bool CanAttack()
    {
        if (Time.time >= enemy_00.lastTimeAttacked + enemy_00.attackCooldown)
        {
            enemy_00.lastTimeAttacked = Time.time; 
            return true;
        }
        return false;
    }
}
