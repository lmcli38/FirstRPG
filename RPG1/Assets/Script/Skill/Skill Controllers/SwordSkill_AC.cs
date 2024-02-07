using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill_AC : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    CircleCollider2D cd;
    Player player;

    bool canRotate = true;


    public bool isBouncing = true;
    public int amountOfBounce = 4;
    public List<Transform> enemyTarget;
    private int targetIndex;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void SetUPSword(Vector2 _dir, float _gravityScale)
    {
        rb.velocity = _dir;
        rb.angularVelocity = _gravityScale;

        anim.SetBool("Rotation", true);
    }
    private void Update()
    {
        if(canRotate) { transform.right = rb.velocity; }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        StuckInto(collision);
        if(collision.GetComponent<enemy>() != null) 
        {
            enemy enemy0 = collision.GetComponent<enemy>();
            player.stats.DoDamage(enemy0.GetComponent<CharacterStats>());
        }
        
    }

    private void StuckInto(Collider2D collision)
    {
        anim.SetBool("Rotation", false);

        canRotate = false;
        cd.enabled = false;

        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        transform.parent = collision.transform;
    }
}
