using System.Collections.Generic;
using UnityEngine;

public class AirBlade_AC : MonoBehaviour
{
    public float damageMultiplier = 1.0f;
    public List<Modification> modifiers = new List<Modification>();

    private void Start()
    {
        foreach (var modifier in modifiers)
        {
            modifier.ApplyModifier(this);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //base.OnTriggerEnter2D(collision);
        if (collision.GetComponent<enemy>() != null)
        {
            PlayerStat playerStat = PlayerManager.instance.player.GetComponent<PlayerStat>();
            EnemyStat enemyTarget = collision.GetComponent<EnemyStat>();
            playerStat.DoMagicalDamage(enemyTarget, damageMultiplier);

            /*
            enemy enemy0 = collision.GetComponent<enemy>();
            player.stats.DoDamage(enemy0.GetComponent<CharacterStats>());*/
        }
    }

}




/*
public class AirBlade_AC : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private EdgeCollider2D edgeCollider;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    public void SetupAirBlade(Vector2 _dir, float _gravityScale,Player _player)
    {
        player = _player;
        rb.velocity = _dir;
        rb.gravityScale = _gravityScale;

        Destroy(gameObject, .8f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<enemy>() != null) 
        {
            
            enemy enemy0 = collision.GetComponent<enemy>();
            player.stats.DoDamage(enemy0.GetComponent<CharacterStats>());

            
            PlayerStat playerStat = PlayerManager.instance.player.GetComponent<PlayerStat>();
            EnemyStat enemyTarget = collision.GetComponent<EnemyStat>();

            playerStat.DoMagicalDamage(enemyTarget);

            Destroy(gameObject);

        }
    }



}
*/