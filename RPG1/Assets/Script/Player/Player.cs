using System.Collections;
using UnityEngine;

public class Player : Entity
{
    [Header("Attack Info")]
    public Vector2[] attackMovement;



    public bool isBusy { get; private set; }
    [Header("Move Info")]
    public float moveSpeed = 4f;
    public float jumpForce;


    [Header("Dash Info")]
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }
    public SkillManager skill { get; private set; }

    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerAttack0State attack0 { get; private set; }
    public PlayerDeadState deadState { get; private set; }

    public PlayerAimState aimState { get; private set; }
    public PlayerCatchState catchState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        attack0 = new PlayerAttack0State(this, stateMachine, "Attack");
        deadState = new PlayerDeadState(this, stateMachine, "Die");

        aimState = new PlayerAimState(this, stateMachine, "Aim");
        catchState = new PlayerCatchState(this, stateMachine, "Catch");
    }

    protected override void Start()
    {
        base.Start();

        skill = SkillManager.instance;
        stateMachine.Initialize(idleState);
    }


    protected override void Update()
    {
        if (Time.timeScale == 0)
            return;

        base.Update();
        stateMachine.currentState.Update();
        CheckForDashState();

        if (Input.GetKeyDown(KeyCode.F)) { skill.fireball.CanUseSkill(); }
    }
    public override void SlowEntityBy(float _slowPercentage, float _slowduration)
    {
        base.SlowEntityBy(_slowPercentage, _slowduration);
    }
    protected override void ReturnDefaultSpeed()
    {
        base.ReturnDefaultSpeed();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }

    void CheckForDashState()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dash.CanUseSkill())
        {

            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
            {
                dashDir = facingDir;
            }

            stateMachine.ChangeState(dashState);
        }
    }


    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public override void Die()
    {
        base.Die();

        stateMachine.ChangeState(deadState);
    }
}
