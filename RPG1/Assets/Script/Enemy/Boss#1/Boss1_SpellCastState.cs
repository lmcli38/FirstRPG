using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_SpellCastState : enemyState
{
    private Boss_1 bossEnemy;

    private float amountOfSpells;
    private float spellTimer;
    public Boss1_SpellCastState(enemy _enemyBase, enemyStateMachine _stateMachine, string _animBoolName, Boss_1 bossEnemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.bossEnemy = bossEnemy;
    }

    public override void Enter()
    {
        base.Enter();

        amountOfSpells = bossEnemy.amountOfSpells;
        spellTimer = .5f;
    }
    public override void Update() 
    {
        base.Update();

        spellTimer -= Time.deltaTime;

        if (CanCast())
            bossEnemy.CastSpell();

        if(amountOfSpells <= 0) 
            stateMachine.ChangeState(bossEnemy.TPState);
    }
    public override void Exit()
    {
        base.Exit();

        bossEnemy.lastTimeCast = Time.time;
    }
    private  bool CanCast()
    {
        if(amountOfSpells > 0 && spellTimer <0)
        {
            amountOfSpells--;
            spellTimer = bossEnemy.spellCooldown;
            return true;
        }
        return false;
    }
}


