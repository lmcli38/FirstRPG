using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_AC : MonoBehaviour
{
    Animator anim => GetComponent<Animator>();
    CircleCollider2D cd => GetComponent<CircleCollider2D>();
    float fireballExitTimer;

    bool canExplode;
    bool canMove;
    float moveSpeed;

    public void SetUpFireBall(float _fireballDuration,bool _canExplode,bool _canMove,float _moveSpeed)
    {
        fireballExitTimer = _fireballDuration;
        canExplode= _canExplode;
        canMove= _canMove;
        moveSpeed = _moveSpeed;
    }

    private void Update()
    {
        fireballExitTimer -= Time.deltaTime;

        FinishFireBall();
    }

    public void FinishFireBall()
    {
        if (fireballExitTimer < 0)
        {
            if (canExplode)
            {
                anim.SetTrigger("Explode");
            }
            else
            {
                SelfDestroy();
            }
        }
    }

    private void AnimationExplodeEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, cd.radius);
        foreach(var hit in  colliders) 
        {
            if (hit.GetComponent<enemy>() != null)
                hit.GetComponent<enemy>().DamageEffect();
        }

    }

    public void SelfDestroy()=>Destroy(gameObject);
}
