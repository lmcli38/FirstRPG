using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_DeadState : enemyState
{
    enemy_0 enemy_00;
    public enemy_0_DeadState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, enemy_0 _enemy_00) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy_00 = _enemy_00;
    }

    public override void Enter()
    {
        base.Enter();
        enemy_00.anim.SetBool(enemy_00.lastAnimBoolName, true);
        enemy_00.anim.speed = 0;
        enemy_00.cd.enabled = false;

        stateTimer = 0.13f;
    }


    public override void Update()
    {
        base.Update();

        if(stateTimer >0)
        {
            rb.velocity = new Vector2(0, 15);
        }
    }
}

