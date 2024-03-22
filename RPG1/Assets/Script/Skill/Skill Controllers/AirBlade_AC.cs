using UnityEngine;

public class AirBlade_AC : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private EdgeCollider2D edgeCollider;
    private Rigidbody2D rb;

    private void Awake()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }

    public void SetupAirBlade(Vector2 _dir, float _gravityScale)
    {
        rb.velocity = _dir;
        rb.gravityScale = _gravityScale;
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<enemy>() != null) 
        {
            EnemyStat enemyTarget = collision.GetComponent<EnemyStat>();

            playerStats.DoDamage(enemyTarget);
        }
    }*/


}
