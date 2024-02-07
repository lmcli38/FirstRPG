using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_SpellCastState : enemyState
{
    private Boss_1 bossEnemy;
    public Boss1_SpellCastState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, Boss_1 bossEnemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.bossEnemy = bossEnemy;
    }
}


