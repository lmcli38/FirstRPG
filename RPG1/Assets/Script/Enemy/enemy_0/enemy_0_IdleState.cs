using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_IdleState : enemy_0_groundState
{
    public enemy_0_IdleState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, enemy_0 enemy_00) : base(_enemyBase, _stateMachine, _animBoolName, enemy_00)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy_00.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0) 
        {
            stateMachine.ChangeState(enemy_00.moveState);
        }

    }
}
