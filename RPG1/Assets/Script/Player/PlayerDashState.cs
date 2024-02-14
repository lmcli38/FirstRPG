using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTime = player.dashDuration;

        player.stats.MakeInvinciblee(true);
    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, rb.velocity.y);
        player.stats.MakeInvinciblee(false);
    }

    public override void Update()
    {
        base.Update();


        player.SetVelocity(player.dashSpeed * player.dashDir, 0);
        if(stateTime < 0) 
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
