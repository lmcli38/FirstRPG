using UnityEngine;
using UnityEngine.UI;

public class enemy_0 : enemy
{
    #region
    public enemy_0_IdleState idleState { get; private set; }
    public enemy_0_MoveState moveState { get; private set; }
    public enemy_0_BattleState battleState { get; private set; }
    public enemy_0_attackState attackState { get; private set; }
    public enemy_0_DeadState deadState { get; private set; }
    public enemy_0_StunState stunState { get; private set; }


    #endregion
    protected override void Awake()
    {
        base.Awake();

        idleState = new enemy_0_IdleState(this, stateMachine, "Idle", this);
        moveState = new enemy_0_MoveState(this, stateMachine, "Move", this);
        battleState = new enemy_0_BattleState(this, stateMachine, "Move", this);
        attackState = new enemy_0_attackState(this, stateMachine, "Attack", this);
        deadState = new enemy_0_DeadState(this, stateMachine, "Idle", this);
        stunState = new enemy_0_StunState(this, stateMachine, "Stun", this);

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.P))
        {
            stateMachine.ChangeState(stunState);
        }
    }

    public override bool CanBeStunned()
    {
        if(base.CanBeStunned())
        {
            stateMachine.ChangeState(stunState);
            return true;
        }
        return false;
    }

    public override void Die()
    {
        base.Die();

        stateMachine.ChangeState(deadState);
    }
}
