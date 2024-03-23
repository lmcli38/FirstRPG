using UnityEngine;

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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<enemy>() != null) 
        {
            enemy enemy0 = collision.GetComponent<enemy>();
            player.stats.DoDamage(enemy0.GetComponent<CharacterStats>());
            Destroy(gameObject);
        }
    }



}
