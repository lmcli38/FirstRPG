using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_TPState : enemyState
{
    private Boss_1 bossEnemy;
    public Boss1_TPState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName,Boss_1 _bossEnemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        bossEnemy = _bossEnemy;
    }
    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
            if (bossEnemy.CanDoSpellCast())
                stateMachine.ChangeState(bossEnemy.SpellCastState);
            else
                stateMachine.ChangeState(bossEnemy.BattleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}


