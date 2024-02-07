using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Boss1_IdleState : enemyState
{
    private Boss_1 bossEnemy;
    public Boss1_IdleState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName,Boss_1 bossEnemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.bossEnemy = bossEnemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = bossEnemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.V)) 
        {
            stateMachine.ChangeState(bossEnemy.TPState);
        }

    }
}
