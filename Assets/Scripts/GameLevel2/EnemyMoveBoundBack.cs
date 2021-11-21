using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBoundBack : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        EnemyRayCast();
    }

    private void EnemyRayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        RaycastHit2D r_hit = Physics2D.Raycast(transform.position, new Vector2(-XMoveDirection, 0));
        if (hit.collider != null && hit.distance < 0.48f)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                PlayerHealthLevel2.Die();
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
                XMoveDirection *= -1;
            }
        }

        // Reverse hit, check die for player
        if (r_hit.collider != null && r_hit.distance < 0.48f)
        {
            if (r_hit.collider.gameObject.tag == "Player")
            {
                PlayerHealthLevel2.Die();
            }
        }
    }
}
