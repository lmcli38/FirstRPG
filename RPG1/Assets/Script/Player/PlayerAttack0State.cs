using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack0State : PlayerState
{

    int comboCounter;

    float lastTimeAttacked;
    float comboWindow = 0.5f;
    public PlayerAttack0State(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        xInput = 0; // to fix bug on attack direction

        if(comboCounter > 3 || Time.time >= lastTimeAttacked + comboWindow) 
        {
            comboCounter = 0;        
        }
        player.anim.SetInteger("comboCounter", comboCounter);
        float attackDir = player.facingDir;
        if(xInput !=0)
        {
            attackDir = xInput;
        }

        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir , player.attackMovement[comboCounter].y);//move forward during attacking 
        stateTime = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine("BusyFor", .5f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if(stateTime <0)
        {
            player.SetZeroVelocity();
        }
        if(triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}


