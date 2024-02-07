using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss_1 : enemy
{
    [Header("TP detail")]
    [SerializeField] private BoxCollider2D arena;
    [SerializeField] private Vector2 surroundingCheckSize;

    [Header("Teleport details")]
    //[SerializeField] private BoxCollider2D arena;
    //[SerializeField] private Vector2 surroundingCheckSize;
    public float chanceToTeleport;
    public float defaultChanceToTeleport = 25;

    #region States
    public Boss1_IdleState IdleState { get; private set; }
    public Boss1_AttackState AttackState { get; private set; }
    public Boss1_BattleState BattleState { get; private set; }
    public Boss1_DeadState DeadState { get; private set; }

    public Boss1_TPState TPState { get; private set; }
    public Boss1_SpellCastState SpellCastState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();

        SetUpDefailtFacingDir(-1);
        
        IdleState = new Boss1_IdleState(this, stateMachine,"Idle",this);
        BattleState = new Boss1_BattleState(this, stateMachine, "Move", this);
        AttackState = new Boss1_AttackState(this, stateMachine, "Attack", this);
        DeadState = new Boss1_DeadState(this, stateMachine, "Idle", this);
        TPState = new Boss1_TPState(this, stateMachine, "Teleport", this);
        SpellCastState = new Boss1_SpellCastState(this, stateMachine, "SpellCast", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(IdleState);
    }
    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(DeadState);
    }
    public void FIndPosition()
    {
        float x = Random.Range(arena.bounds.min.x + 3, arena.bounds.max.x - 3);
        float y = Random.Range(arena.bounds.min.y + 3, arena.bounds.max.y - 3);

        transform.position = new Vector3(x, y);
        transform.position = new Vector3(transform.position.x, transform.position.y - GroundBelow().distance + (cd.size.y / 2));

        if(!GroundBelow()|| SomethingIsAround())
        {
            Debug.Log("looking for new position");
            FIndPosition();
        }
    }


    private RaycastHit2D GroundBelow() => Physics2D.Raycast(transform.position, Vector2.down, 100, whatIsGround);
    private bool SomethingIsAround() => Physics2D.BoxCast(transform.position, surroundingCheckSize, 0, Vector2.zero, 0, whatIsGround);
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x, transform.position.y - GroundBelow().distance));
        Gizmos.DrawWireCube(transform.position, surroundingCheckSize);
    }

    public bool CanTeleport()
    {
        if (Random.Range(0, 100) <= chanceToTeleport)
        {
            chanceToTeleport = defaultChanceToTeleport;
            return true;
        }

        return false;
    }
    /*public bool CanDoSpellCast()
    {
        if (Time.time >= lastTimeCast + spellStateCooldown)
        {
            return true;
        }

        return false;
    }*/
}
