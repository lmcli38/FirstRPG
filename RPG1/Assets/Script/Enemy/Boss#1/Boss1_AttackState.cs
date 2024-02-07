using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_AttackState : enemyState
{
    private Boss_1 bossEnemy;
    public Boss1_AttackState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName,Boss_1 bossEnemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.bossEnemy = bossEnemy;
    }

    public override void Enter()
    {
        base.Enter();

        bossEnemy.chanceToTeleport += 5;
    }

    public override void Exit()
    {
        base.Exit();
        bossEnemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        bossEnemy.SetZeroVelocity();

        if (triggerCalled)
        {
            if(bossEnemy.CanTeleport())
                stateMachine.ChangeState(bossEnemy.TPState);
            else
                stateMachine.ChangeState(bossEnemy.BattleState);
        }
    }
}
