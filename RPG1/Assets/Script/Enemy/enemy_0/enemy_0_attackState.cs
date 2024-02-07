using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_attackState : enemyState
{
    enemy_0 enemy_00;
    public enemy_0_attackState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, enemy_0 enemy_00) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy_00 = enemy_00;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemy_00.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy_00.SetZeroVelocity();

        if(triggerCalled) 
        {
            stateMachine.ChangeState(enemy_00.battleState);
        }
    }
}


