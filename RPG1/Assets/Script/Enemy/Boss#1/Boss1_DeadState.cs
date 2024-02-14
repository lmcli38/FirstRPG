using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_DeadState : enemyState
{
    private Boss_1 bossEnemy;
    public Boss1_DeadState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, Boss_1 bossEnemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.bossEnemy = bossEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        bossEnemy.anim.SetBool(bossEnemy.lastAnimBoolName, true);
        bossEnemy.anim.speed = 0;
        bossEnemy.cd.enabled = false;

        stateTimer = 0.01f;
    }


    public override void Update()
    {
        base.Update();

        if (stateTimer > 0)
        {
            rb.velocity = new Vector2(0, 15);
        }
    }
}
