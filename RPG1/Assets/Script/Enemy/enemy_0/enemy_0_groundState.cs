using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_groundState : enemyState
{
    protected enemy_0 enemy_00;
    protected Transform player;
    public enemy_0_groundState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, enemy_0 enemy_00) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy_00 = enemy_00;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();


        if(enemy_00.IsPlayerDetected() || Vector2.Distance(enemy_00.transform.position, player.position)<2)
        {
            stateMachine.ChangeState(enemy_00.battleState);
        }
    }
}
