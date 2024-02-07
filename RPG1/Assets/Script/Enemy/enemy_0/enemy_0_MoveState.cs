using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_MoveState : enemy_0_groundState
{
    public enemy_0_MoveState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, enemy_0 enemy_00) : base(_enemyBase, _stateMachine, _animBoolName, enemy_00)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy_00.SetVelocity(enemy_00.movespeed * enemy_00.facingDir, rb.velocity.y);

        if(enemy_00.IsWallDetected() || !enemy_00.IsGroundDetected())
        {
            enemy_00.Flip();
            stateMachine.ChangeState(enemy_00.idleState);
        }
    }
}
