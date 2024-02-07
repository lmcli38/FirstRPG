using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class enemyState
{
    protected enemyStateMachine stateMachine;
    protected enemy EnemyBase;
    protected Rigidbody2D rb;

    protected bool triggerCalled;
    string animBoolName;

    protected float stateTimer;

    public enemyState (enemy _enemyBase,enemyStateMachine _stateMachine,string _animBoolName)
    {
        this.EnemyBase = _enemyBase;
        this.animBoolName = _animBoolName;
        this.stateMachine = _stateMachine;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Enter () 
    { 
        triggerCalled = false;
        rb = EnemyBase.rb;
        EnemyBase.anim.SetBool(animBoolName, true);

    }
    public virtual void Exit () 
    {
        EnemyBase.anim.SetBool(animBoolName, false);
        EnemyBase.AssignLastAnimName(animBoolName);

    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
