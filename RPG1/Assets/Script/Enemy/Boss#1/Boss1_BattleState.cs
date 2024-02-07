using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Boss1_BattleState : enemyState
{
    private Boss_1 bossEnemy;
    private Transform player;
    private int moveDir;
    public Boss1_BattleState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName,Boss_1 bossEnemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.bossEnemy = bossEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;

        //if (player.GetComponent<PlayerStat>().isDead) { }
            //stateMachine.ChangeState(bossEnemy.moveState);
    }


    public override void Update()
    {
        base.Update();

        if (bossEnemy.IsPlayerDetected())
        {
            stateTimer = bossEnemy.battleTime;
            if (bossEnemy.IsPlayerDetected().distance < bossEnemy.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(bossEnemy.AttackState);
                else
                    stateMachine.ChangeState(bossEnemy.IdleState);
            }
        }

        if (player.position.x > bossEnemy.transform.position.x)
            moveDir = 1;
        else if (player.position.x < bossEnemy.transform.position.x)
            moveDir = -1;
        if (bossEnemy.IsPlayerDetected() && bossEnemy.IsPlayerDetected().distance < bossEnemy.attackDistance - .1f)
            return;

        bossEnemy.SetVelocity(bossEnemy.movespeed * moveDir, rb.velocity.y);
    }
    public override void Exit()
    {
        base.Exit();
    }

    bool CanAttack()
    {
        if (Time.time >= bossEnemy.lastTimeAttacked + bossEnemy.attackCooldown)
        {
            bossEnemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}

