using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_StunState : enemyState
{
    private enemy_0 enemy_00;
    public enemy_0_StunState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, enemy_0 enemy_00) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy_00 = enemy_00;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy_00.stunDuration;
        rb.velocity=new Vector2(-enemy_00.facingDir * enemy_00.stunDirection.x, enemy_00.stunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer<0)
            stateMachine.ChangeState(enemy_00.idleState);
    }
}
